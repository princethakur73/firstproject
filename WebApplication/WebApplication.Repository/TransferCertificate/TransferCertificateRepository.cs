
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class TransferCertificateRepository : ITransferCertificateRepository
    {
        private string query { get; set; }

        public List<Core.TransferCerticate> GetAll(long currentUserId)
        {
            List<TransferCerticate> list;
            try
            {
                query = @"SELECT d.Id,
                                d.studentname as Name,
                                cm.RomanName as ClassName,
                                d.admissionnumber as AdmissionNo,                               
                                d.FileName
                            FROM transfercertificate d
                            join classmaster cm on d.class=cm.id 
		                    Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<TransferCerticate>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.TransferCerticate GetById(int id)
        {
            TransferCerticate data;
            try
            {
                query = @"SELECT d.Id,
                                d.Class as ClassMasterId,
                                d.studentname StudentName,
                                cm.RomanName as ClassName,
                                d.AdmissionNumber,
                                d.FileName,
                                d.Extenstion,                                
                                d.CreateByDate,
                                d.CreateByUserId,
                                d.ModifyByDate,
                                d.ModifyByUserId
                            FROM transfercertificate d
                            join classMaster cm on d.Class=cm.Id 
		                     where d.Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<TransferCerticate>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.TransferCerticate obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_ClassMasterId", obj.ClassMasterId, DbType.Int32);
                param.Add("_AdmissionNo", obj.AdmissionNumber, DbType.String);
                param.Add("_StudentName", obj.StudentName, DbType.String);
                param.Add("_FileNames", obj.FileName, DbType.String);
                param.Add("_Extenstion", obj.Extenstion, DbType.String);                
                param.Add("_UserId", obj.UserId, DbType.Int32);

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_TransferCertificate", param, commandType: CommandType.StoredProcedure);
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
                query = @"Delete from transfercertificate where Id=@Id;";
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
                    query = @"Select count(Id) from transfercertificate where Name=_Name";
                }
                else
                {
                    query = @"Select count(Id) from transfercertificate where Name=_Name and Id!=_Id";
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

        public List<TransferCerticate> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<TransferCerticate> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<TransferCerticate>("Sp_Select_TransferCertificate_List", param: param, commandType: CommandType.StoredProcedure).ToList();
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
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_TransferCertificate_List", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return countTotal;
        }

        public List<Core.TransferCerticate> GetListOnAdmissionBase(string searchtext)
        {
            List<TransferCerticate> list;
            try
            {
                query = @"SELECT d.Id,
                                d.studentname as Name,
                                cm.RomanName as ClassName,
                                d.admissionnumber as AdmissionNo,                               
                                d.FileName
                            FROM transfercertificate d
                            join classmaster cm on d.class=cm.id 
                            WHERE d.admissionnumber LIKE '%"+searchtext+"%' Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<TransferCerticate>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

    }
}