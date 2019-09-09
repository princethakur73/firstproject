using Dapper;
using Microsoft.AspNet.Identity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class UserLoginsRepository
    {
        /// <summary>
        /// Deletes a login from a user in the UserLogins table
        /// </summary>
        /// <param name="user">User to have login deleted</param>
        /// <param name="login">Login to be deleted from user</param>
        /// <returns></returns>
        public void Delete(User user, UserLoginInfo login)
        {
            try
            {

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Delete from userlogins 
                    where UserId = @userId 
                    and LoginProvider = @loginProvider 
                    and ProviderKey = @providerKey",
                    new
                    {
                        userId = user.Id,
                        loginProvider = login.LoginProvider,
                        providerKey = login.ProviderKey
                    });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Deletes all Logins from a user in the UserLogins table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public void Delete(int userId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Delete from userlogins 
                    where UserId = @userId", new { userId = userId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new login in the UserLogins table
        /// </summary>
        /// <param name="user">User to have new login added</param>
        /// <param name="login">Login to be added</param>
        /// <returns></returns>
        public void Insert(User user, UserLoginInfo login)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Insert into userlogins 
                (LoginProvider, ProviderKey, UserId) 
                values (@loginProvider, @providerKey, @userId)",
                        new
                        {
                            loginProvider = login.LoginProvider,
                            providerKey = login.ProviderKey,
                            userId = user.Id
                        });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Return a userId given a user's login
        /// </summary>
        /// <param name="UserLogins">The user's login info</param>
        /// <returns></returns>
        public long FindUserIdByLogin(UserLoginInfo UserLogins)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<long>(@"Select UserId from userlogins 
                where LoginProvider = @loginProvider and ProviderKey = @providerKey",
               new
               {
                   loginProvider = UserLogins.LoginProvider,
                   providerKey = UserLogins.ProviderKey
               });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Returns a list of user's logins
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public List<UserLoginInfo> FindByUserId(long UserId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.Query<UserLoginInfo>("Select * from userlogins where UserId = @UserId", new { UserId = UserId })
                    .ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
