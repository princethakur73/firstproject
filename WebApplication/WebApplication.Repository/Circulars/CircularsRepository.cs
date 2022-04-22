
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class CircularsRepository : ICircularsRepository
    {
        private string _query { get; set; }

        public List<Circulars> GetAll(long currentUserId)
        {
            List<Circulars> list;
            try
            {
                _query = @"SELECT d.Id,
                                d.Title,
                                d.CreateByDate,                               
                                d.FileName,
                                d.Extenstion
                            FROM Circulars d                            
		                    Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Circulars>(_query).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public Circulars GetById(int id)
        {
            Circulars data;
            try
            {
                _query = @"SELECT d.Id,
                                d.Title,                                
                                d.FileName,
                                d.Extenstion,   
                                d.SortId,
                                d.IsActive,
                                d.CreateByDate,
                                d.CreateByUserId,
                                d.ModifyByDate,
                                d.ModifyByUserId
                            FROM Circulars d
		                     where d.Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<Circulars>(_query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }

        public int Save(Core.Circulars obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_Title", obj.Title, DbType.String);                
                param.Add("_FileNames", obj.FileName, DbType.String);
                param.Add("_Extenstion", obj.Extenstion, DbType.String);
                param.Add("_SortId", obj.SortId, DbType.Int32);
                param.Add("_IsActive", obj.IsActive, DbType.Boolean);
                param.Add("_UserId", obj.UserId, DbType.Int32);

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_Circulars", param, commandType: CommandType.StoredProcedure);
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
                _query = @"Delete from Circulars where Id=@Id;";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.Execute(_query, new { Id = id });
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
                    _query = @"Select count(Id) from Circulars where Name=_Name";
                }
                else
                {
                    _query = @"Select count(Id) from Circulars where Name=_Name and Id!=_Id";
                }
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.ExecuteScalar<int>(_query, new { Name = name, Id = id });
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

        public List<Circulars> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Circulars> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Circulars>("Sp_Select_Circulars_List", param: param, commandType: CommandType.StoredProcedure).ToList();
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
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_Circulars_List", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return countTotal;
        }

        #region PTM
        public Ptm GetByIdPtm(int? id)
        {
            Ptm data;
            try
            {
                _query = @"SELECT p.Id,
		                        p.Month,
		                        p.Title,                               
		                        p.Class,
		                        p.Time,
                                p.SortId,
                                p.CreatebyDate,
                                p.IsActive
                        FROM Ptm p              
                        Where p.id=@Id              
                        Order By p.SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<Ptm>(_query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }

        public int SavePTM(Core.Ptm obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_Month", obj.Month, DbType.DateTime);
                param.Add("_Title", obj.Title, DbType.String);
                param.Add("_Class", obj.Class, DbType.String);
                param.Add("_Time", obj.Time, DbType.String);
                param.Add("_SortId", obj.SortId, DbType.Int32);
                param.Add("_IsActive", obj.IsActive, DbType.Boolean);
                param.Add("_UserId", obj.UserId, DbType.Int32);

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_Ptm", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Id;
        }

        public bool DeleteByIdPtm(int id)
        {
            bool isDeleted = false;
            try
            {
                _query = @"Delete from Ptm where Id=@Id;";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.Execute(_query, new { Id = id });
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

        public bool IsNameExistPtm(string name, int id)
        {
            bool isDeleted = false;
            try
            {
                if (id == 0)
                {
                    _query = @"Select count(Id) from Ptm where Name=_Name";
                }
                else
                {
                    _query = @"Select count(Id) from Ptm where Name=_Name and Id!=_Id";
                }
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.ExecuteScalar<int>(_query, new { Name = name, Id = id });
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

        public List<Ptm> GetListPtm(int pageNo = 1, int pageSize = 10)
        {
            List<Ptm> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Ptm>("Sp_Select_Ptm_List", param: param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        #endregion
    }
}