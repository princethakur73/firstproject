using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Core;
namespace WebApplication.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private string query { get; set; }

        public List<Core.Video> GetAll(long currentUserId)
        {
            List<Video> list;
            try
            {
                query = @"Select Id,
			                   Name, 
                                Title,			                    
                                Extension,	                    
			                    CreateByDate, 
			                    CreateByUserId,
			                    ModifyByDate, 
			                    ModifyByUserId			                    	   
			                    from Video
		                Order By Name";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Video>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.Video GetById(int id)
        {
            Video data;
            try
            {
                query = @"Select Id,
			                    Name, 
                                Title,			                    
                                Extension,
			                    CreateByDate, 
			                    CreateByUserId,
			                    ModifyByDate, 
			                    ModifyByUserId,			                    
			                    from Video
		                 where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<Video>(query, param: new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.Video obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("Id", obj.Id, DbType.Int32);
                param.Add("Title", obj.Title, DbType.String);
                param.Add("Name", obj.Name, DbType.String);
                param.Add("Extension", obj.Extension, DbType.String);
                param.Add("UserId", obj.UserId, DbType.Int32);

                if (obj.Id == 0)
                {
                    query = @" if((select count(Id) from Video where Name =@Name)=0)
                                begin
                                        INSERT INTO [dbo].[Video]
                                        ([Title]
                                        ,[Name]
                                        ,[Extension]
                                        ,[CreateByDate]
                                        ,[CreateByUserId]
                                        ,[ModifyByDate]
                                        ,[ModifyByUserId])
                                        VALUES
                                        (@Title
                                        ,@Name
                                        ,@Extension
                                        ,getdate()
                                        ,@UserId
                                        ,getdate()
                                        ,@UserId)
                                    Select Scope_Identity()
                                end
                                else
                                begin
                                    select 1;
                                end";
                    using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                    {
                        Id = Db.ExecuteScalar<int>(query, param);
                    }
                }
                else
                {
                    query = @"UPDATE [dbo].[Video]
                                       SET [Title] = @Title
                                          ,[Name] = @Name
                                          ,[Extension] = @Extension
                                          ,[ModifyByDate] =getdate()
                                          ,[ModifyByUserId] = @UserId
                                 WHERE Id=@Id;
                            Select @@rowcount";
                    using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                    {
                        Id = Db.ExecuteScalar<int>(query, param);
                        if (Id > 0)
                        {
                            Id = obj.Id;
                        }
                    }
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
                query = @"Delete from Video where Id=@Id; select @@rowcount";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.ExecuteScalar<int>(query, new { Id = id });
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
                    query = @"Select count(Id) from Video where Name=@Name";
                }
                else
                {
                    query = @"Select count(Id) from Video where Name=@Name and Id!=@Id";
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

        public List<Video> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Video> list;
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Video>("Sp_Video_List", param: new { IsCount = 0, PageNo = pageNo, PageSize = pageSize }, commandType: CommandType.StoredProcedure).ToList();
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
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    countTotal = Db.ExecuteScalar<int>("Sp_Video_List", new { IsCount = 1, PageNo = pageNo, PageSize = pageSize }, commandType: CommandType.StoredProcedure);
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