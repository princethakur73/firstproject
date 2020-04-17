
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;
using WebApplication.Core.Model;

namespace WebApplication.Repository
{
    public class StaffDetailRepository : IStaffDetailRepository
    {
        private string query { get; set; }


        public List<Core.StaffDetail> GetAll(long currentUserId)
        {

            List<StaffDetail> list;
            try
            {
                query = @"SELECT Id,
                                GroupId,
                                DepartmentId,
                                Name,
                                Image,
                                Desigination,
                                AppointmentDate,
                                ProfessionalQualification,
                                AcadmicQualification,
                                TrainingStatus,
                                JobStatus,
                                IsActive,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                           FROM staffdetail
                           Where IsActive=1 
		                    Order By SortId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<StaffDetail>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.StaffDetail GetById(int id)
        {
            StaffDetail data;
            try
            {
                query = @"SELECT Id,
                                GroupId,
                                DepartmentId,
                                Name,
                                Image,
                                Desigination,
                                AppointmentDate,
                                ProfessionalQualification,
                                AcadmicQualification,
                                TrainingStatus,
                                JobStatus,
                                SortId,
                                IsActive,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                           FROM staffdetail
		                     where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<StaffDetail>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.StaffDetail obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_Name", obj.Name, DbType.String);
                param.Add("_Desigination", obj.Desigination, DbType.String);
                param.Add("_Image", obj.Image, DbType.String);
                param.Add("_GroupId", obj.GroupId, DbType.String);
                param.Add("_DepartmentId", obj.DepartmentId, DbType.Int32);
                param.Add("_AppointmentDate", obj.AppointmentDate, DbType.Date);
                param.Add("_ProfessionalQualification", obj.ProfessionalQualification, DbType.String);
                param.Add("_AcadmicQualification", obj.AcadmicQualification, DbType.String);
                param.Add("_TrainingStatus", obj.TrainingStatus, DbType.String);
                param.Add("_JobStatus", obj.JobStatus, DbType.String);
                param.Add("_IsActive", obj.IsActive, DbType.Boolean);
                param.Add("_SortId", obj.SortId, DbType.Int32);
                param.Add("_UserId", obj.UserId, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.Execute("Sp_Save_StaffDetail", param, commandType: CommandType.StoredProcedure);
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
                query = @"Delete from StaffDetail where Id=@Id;";
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
                    query = @"Select count(Id) from StaffDetail where Name=_Name";
                }
                else
                {
                    query = @"Select count(Id) from StaffDetail where Name=_Name and Id!=_Id";
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

        public List<StaffDetail> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<StaffDetail> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<StaffDetail>("Sp_Select_StaffDetail_List", param: param, commandType: CommandType.StoredProcedure).ToList();
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
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_StaffDetail_List", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return countTotal;
        }

        public List<StaffModel> GetStaffList()
        {
            List<StaffModel> list;
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<StaffModel>("sp_Staff_List", param: null, commandType: CommandType.StoredProcedure).ToList();
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