using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class UserRolesRepository
    {


        /// <summary>
        /// Returns a list of user's roles
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public List<string> FindByUserId(long userId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.Query<string>("Select Roles.Name from userroles, roles where userroles.UserId=@UserId and userroles.RoleId = roles.Id", new { UserId = userId }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Deletes all roles from a user in the UserRoles table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public void Delete(long userId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Delete from userroles where Id = @UserId", new { UserId = userId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Inserts a new role for a user in the UserRoles table
        /// </summary>
        /// <param name="user">The User</param>
        /// <param name="roleId">The Role's id</param>
        /// <returns></returns>
        public void Insert(User user, int roleId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Insert into userroles (UserId, RoleId) values (@userId, @roleId",
                    new { userId = user.Id, roleId = roleId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
