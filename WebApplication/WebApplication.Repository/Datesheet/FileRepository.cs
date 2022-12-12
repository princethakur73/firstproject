
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class FileRepository : IFileRepository
    {
        private string query { get; set; }
        public int Save(Core.File obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_Session", obj.Session, DbType.Date);
                param.Add("_FileNames", obj.FileName, DbType.String);
                param.Add("_Type", obj.Type, DbType.Int32);
                param.Add("_IsActive", obj.IsActive, DbType.Boolean);
                param.Add("_UserId", obj.UserId, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_File", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return Id;
        }
        public Core.File GetById(int id)
        {
            File data;
            try
            {
                query = @"SELECT Id,
                                Session,
                                FileName,
                                IsActive,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                IsDeleted
                            FROM file
		                     where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<File>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }
        public List<File> GetList(int pageNo = 1, int pageSize = 10,int type =0)
        {
            List<File> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                param.Add("_Type", type, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<File>("Sp_Select_File_List", param: param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return list;
        }
        public bool DeleteById(int id)
        {
            bool isDeleted = false;
            try
            {
                query = @"Delete from file where Id=@Id;";
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
                    query = @"Select count(Id) from News where Name=_Name";
                }
                else
                {
                    query = @"Select count(Id) from News where Name=_Name and Id!=_Id";
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
        public int GetListCount(int pageNo = 1, int pageSize = 10, int type = 0)
        {
            int countTotal = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 1, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                param.Add("_Type", type, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_File_List", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return countTotal;
        }

        public List<File> GetAll(long currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}