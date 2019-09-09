
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class DownloadsRepository : IDownloadsRepository
    {
        private string query { get; set; }

        public List<Core.Downloads> GetAll(long currentUserId)
        {
            List<Downloads> list;
            try
            {
                query = @"SELECT d.Id,
                                d.ClassMasterId,
                                cm.RomanName as ClassName,
                                d.Date,
                                d.Title,
                                d.FileName,
                                d.SortId,
                                d.IsPublish,
                                d.CreateByDate,
                                d.CreateByUserId,
                                d.ModifyByDate,
                                d.ModifyByUserId
                            FROM downloads d
                            join classmaster cm on d.classmasterId=cm.id 
		                    Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Downloads>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.Downloads GetById(int id)
        {
            Downloads data;
            try
            {
                query = @"SELECT d.Id,
                                d.ClassMasterId,
                                cm.Name as ClassName,
                                d.Date,
                                d.Title,
                                d.FileName,
                                d.SortId,
                                d.IsPublish,
                                d.CreateByDate,
                                d.CreateByUserId,
                                d.ModifyByDate,
                                d.ModifyByUserId
                            FROM downloads d
                            join classMaster cm on d.ClassMasterId=cm.Id 
		                     where d.Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<Downloads>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.Downloads obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_ClassMasterId", obj.ClassMasterId, DbType.Int32);
                param.Add("_Date", obj.Date, DbType.DateTime);
                param.Add("_Title", obj.Title, DbType.String);
                param.Add("_FileNames", obj.FileName, DbType.String);
                param.Add("_SortId", obj.SortId, DbType.Int32);
                param.Add("_IsPublish", obj.IsPublish, DbType.Boolean);
                param.Add("_UserId", obj.UserId, DbType.Int32);

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_Downloads", param, commandType: CommandType.StoredProcedure);
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
                query = @"Delete from Downloads where Id=@Id;";
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
                    query = @"Select count(Id) from Downloads where Name=_Name";
                }
                else
                {
                    query = @"Select count(Id) from Downloads where Name=_Name and Id!=_Id";
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

        public List<Downloads> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Downloads> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Downloads>("Sp_Select_Downloads_List", param: param, commandType: CommandType.StoredProcedure).ToList();
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
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_Downloads_List", param: param, commandType: CommandType.StoredProcedure);
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