
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private string query { get; set; }

        public List<Core.StudentAdmission> GetAll(long currentUserId)
        {
            List<StudentAdmission> list;
            try
            {
                query = @"SELECT t.Id,
                                t.Name,
                                t.ClassMasterId,
                                cm.Name as ClassName,
                                t.CGPA,
                                t.Image,
                                t.SortId,
                                t.CreateByDate,
                                t.CreateByUserId,
                                t.ModifyByDate,
                                t.ModifyByUserId
                                FROM Toppers t
                                join ClassMaster cm on t.ClassMasterId=cm.Id
		                    Order By t.SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<StudentAdmission>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.StudentAdmission GetById(int id)
        {
            StudentAdmission data;
            try
            {
                query = @"SELECT t.Id,
                                t.StudentName,
                                t.Gender,
                                t.DOB,
                                t.FatherName,
                                t.MotherName,
                                t.FatherOccupation,
                                t.Address,
                                t.ClassMasterId,
                                cm.Name as ClassName,
                                t.Contact,
                                t.Category,
                                t.LastBoard,
                                t.LastSchool,
                                t.Image,
                                t.Subject1,
                                t.Subject2,
                                t.Subject3,
                                t.Subject4,
                                t.Subject5,
                                t.SortId,
                                t.CreateByDate                                
                                FROM StudentAdmission t
                                join ClassMaster cm on t.ClassMasterId=cm.Id
		                     where t.Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<StudentAdmission>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.StudentAdmission obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_StudentName", obj.StudentName, DbType.String);
                param.Add("_Gender", obj.Gender, DbType.String);
                param.Add("_DOB", obj.DOB, DbType.DateTime);
                param.Add("_FatherName", obj.FatherName, DbType.String);
                param.Add("_MotherName", obj.MotherName, DbType.String);
                param.Add("_FatherOccupation", obj.FatherOccupation, DbType.String);
                param.Add("_Address", obj.Address, DbType.String);
                param.Add("_Contact", obj.Contact, DbType.String);
                param.Add("_Category", obj.Category, DbType.String);
                param.Add("_LastBoard", obj.LastBoard, DbType.String);
                param.Add("_LastSchool", obj.LastSchool, DbType.String);
                param.Add("_Subject1", obj.Subject1, DbType.String);
                param.Add("_Subject2", obj.Subject2, DbType.String);
                param.Add("_Subject3", obj.Subject3, DbType.String);
                param.Add("_Subject4", obj.Subject4, DbType.String);
                param.Add("_Subject5", obj.Subject5, DbType.String);
                param.Add("_ClassMasterId", obj.ClassMasterId, DbType.Int32);
                param.Add("_Image", obj.Image, DbType.String);
                param.Add("_UserId", obj.UserId, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_StudentAdmission", param, commandType: CommandType.StoredProcedure);
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
                query = @"Delete from StudentAdmission where Id=@Id;";
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
                    query = @"Select count(Id) from Toppers where Name=_Name";
                }
                else
                {
                    query = @"Select count(Id) from Toppers where Name=_Name and Id!=_Id";
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

        public List<StudentAdmission> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<StudentAdmission> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<StudentAdmission>("Sp_Select_Admission_List", param: param, commandType: CommandType.StoredProcedure).ToList();
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
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_Admission_List", param: param, commandType: CommandType.StoredProcedure);
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