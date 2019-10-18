﻿
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class ClassMasterRepository : IClassMasterRepository
    {
        private string query { get; set; }

        public List<Core.ClassMaster> GetAll(long currentUserId)
        {
            List<ClassMaster> list;
            try
            {
                query = @"SELECT Id,
                                Name,
                                RomanName,
                                SortId,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                                FROM ClassMaster
		                    Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<ClassMaster>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.ClassMaster GetById(int id)
        {
            ClassMaster data;
            try
            {
                query = @"SELECT Id,
                                Name,
                                RomanName,
                                SortId,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                                FROM ClassMaster
		                     where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<ClassMaster>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.ClassMaster obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_Name", obj.Name, DbType.String);
                param.Add("_SortId", obj.SortId, DbType.Int32);
                param.Add("_IsActive", obj.IsActive, DbType.Boolean);
                param.Add("_UserId", obj.UserId, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_ClassMaster", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return Id;
        }

        public bool DeleteById(int id)
        {
            bool isDeleted = false;
            try
            {
                query = @"Delete from ClassMaster where Id=@Id;";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.Execute(query, new { Id = id });
                    if (effectedRow > 0)
                        isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return isDeleted;
        }

        public bool IsNameExist(string name, int id)
        {
            bool isDeleted = false;
            try
            {
                if (id == 0)
                {
                    query = @"Select count(Id) from ClassMaster where Name=_Name";
                }
                else
                {
                    query = @"Select count(Id) from ClassMaster where Name=_Name and Id!=_Id";
                }
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.ExecuteScalar<int>(query, new { Name = name, Id = id });
                    if (effectedRow > 0)
                        isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return isDeleted;
        }

        public List<ClassMaster> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<ClassMaster> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<ClassMaster>("Sp_Select_ClassMaster_List", param: param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return list;
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int countTotal = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 1, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_ClassMaster_List", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return countTotal;
        }

    }
}