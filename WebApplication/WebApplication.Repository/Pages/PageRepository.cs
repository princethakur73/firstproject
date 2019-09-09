using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApplication.Core.Common;

namespace WebApplication.Repository
{
    public class PageRepository : IPageRepository
    {
        public string Query { get; set; }


        public bool DeleteById(int Id)
        {
            throw new NotImplementedException();
        }


        public Page GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Page> GetAll(long currentUserId)
        {
            throw new NotImplementedException();
        }


        public Page GetPageByMenuCode(string menuCode)
        {
            Page page = new Page();
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    page = Db.QuerySingleOrDefault<Page>("Select Id,MenuCode,Title,Seo,MetaKeywords,MetaDescription,MetaTitle,Contents,IsPublish,CreateByDate,CreateByUserId,ModifyByDate,ModifyByUserId from Pages where MenuCode=@MenuCode", param: new { MenuCode = menuCode });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return page;
        }

        public int Save(Page obj)
        {
            int result = 0;
            DynamicParameters param = new DynamicParameters();
            param.Add("_Id", obj.Id, System.Data.DbType.Int32);
            param.Add("_MenuCode", obj.MenuCode, System.Data.DbType.String);
            param.Add("_Title", obj.Title, System.Data.DbType.String);
            param.Add("_Seo", obj.Seo, System.Data.DbType.String);
            param.Add("_MetaTitle", obj.MetaTitle, System.Data.DbType.String);
            param.Add("_MetaKeywords", obj.MetaKeywords, System.Data.DbType.String);
            param.Add("_MetaDescription", obj.MetaDescription, System.Data.DbType.String);
            param.Add("_Contents", obj.Contents, System.Data.DbType.String);
            param.Add("_IsPublish", obj.IsPublish, System.Data.DbType.Boolean);
            param.Add("_UserId", obj.UserId, System.Data.DbType.Int32);

            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = Db.Execute("Sp_Save_Page", param: param, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            return result;
        }

        public Task<Page> SaveAsync(Page obj)
        {
            throw new NotImplementedException();
        }


    }
}
