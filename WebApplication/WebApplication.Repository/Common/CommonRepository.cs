using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Core;
using WebApplication.Core.Common;

namespace WebApplication.Repository
{
    public class CommonRepository : ICommonRepository
    {
        public string Query { get; set; }
        public CommonRepository()
        {
        }

        public List<UserMenu> GetUserMenuByUserId(int userId)
        {

            List<UserMenu> list = new List<UserMenu>();
            try
            {
                Query = @"Select  um.Id,
		                        um.MenuId,
		                        um.UserId,
		                        um.RoleId,
		                        um.IsDelete,
		                        um.IsUpdate,
		                        um.IsAccess,
		                        um.IsView,
		                        m.Id,
		                        m.MenuCode,
		                        m.Name,
		                        m.ParentMenuId,
		                        m.Controller,
		                        m.Action,
		                        m.Icon,
		                        m.SortId,
		                        m.IsActive,
		                        r.Id,
		                        r.Name
		                        from usermenu um 
		                        join menu m on um.MenuId=m.Id
		                        join userroles ur on um.UserId=ur.UserId
		                        join roles r on ur.RoleId=r.Id
		                        where um.userId=@UserId";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<UserMenu, Menu, Role, UserMenu>(Query, (um, m, r) => { um.Menu = m; um.Role = r; return um; }, splitOn: "Id,Id,Id", param: new { UserId = userId }).ToList();
                }
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return list;
        }

        public List<Session> GetSessionList()
        {
            List<Session> list = new List<Session>();
            try
            {
                Query = @"SELECT Id,
                                Name,
                                IsActive,
                                SortId,
                                CreateByDate,
                                CreateByUserId
                            FROM session  Where IsActive=1 order by SortId desc";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Session>(Query).ToList();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

            return list;
        }

        public List<Session> GetGallerySessionList()
        {
            List<Session> list = new List<Session>();
            try
            {
                Query = @"SELECT distinct s.Id,
                                s.Name,
                                s.IsActive,
                                s.SortId                            
                            FROM session s
                            join gallery g on s.Id=g.SessionId
                            where s.IsActive=1
                            order by s.SortId desc";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Session>(Query).ToList();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

            return list;
        }

        public Session GetSessionByName(string sessionName)
        {
            Session data = new Session();
            try
            {
                Query = @"SELECT s.Id,
                                s.Name,
                                s.IsActive,
                                s.SortId,
                                s.CreateByDate,
                                s.CreateByUserId
                            FROM session s
                            join gallery g on s.Id=g.SessionId
                            Where s.Name =@Name";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.QueryFirstOrDefault<Session>(Query, new { Name = sessionName });
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

            return data;
        }
    }
}
