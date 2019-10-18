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
    public class MemberRepository : IMemberRepository
    {
        private string query { get; set; }

        public List<Core.Member> GetAllExecutive(long currentUserId)
        {
            List<Member> list;
            try
            {
                query = @"SELECT Id,Name,
                                Desigination,
                                Image,
                                Message,
                                MessageLink,
                                SortId,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                                FROM member
                                WHERE IsActive = 1 AND IsExecutive=1
		                    Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Member>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public List<Core.Member> GetAll(long currentUserId)
        {
            List<Member> list;
            try
            {
                query = @"SELECT Id,
                                Name,
                                Desigination,
                                Image,
                                SortId,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                                FROM member Where Desigination != 'Founder'                               
		                    Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Member>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.Member GetById(int id)
        {
            Member data;
            try
            {
                query = @"SELECT Id,
                                Name,
                                Desigination,
                                Image,
                                SortId,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                                FROM member
		                     where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<Member>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.Member obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_Name", obj.Name, DbType.String);
                param.Add("_Desigination", obj.Desigination, DbType.String);
                param.Add("_Image", obj.Image, DbType.String);
                param.Add("_SortId", obj.SortId, DbType.Int32);
                param.Add("_IsActive", obj.IsActive, DbType.Boolean);
                param.Add("_UserId", obj.UserId, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_Member", param, commandType: CommandType.StoredProcedure);
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
                query = @"Delete from Member where Id=@Id;";
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
                    query = @"Select count(Id) from Member where Name=_Name";
                }
                else
                {
                    query = @"Select count(Id) from Member where Name=_Name and Id!=_Id";
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

        public List<Member> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Member> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Member>("Sp_Select_Member_List", param: param, commandType: CommandType.StoredProcedure).ToList();
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
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_Member_List", param: param, commandType: CommandType.StoredProcedure);
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