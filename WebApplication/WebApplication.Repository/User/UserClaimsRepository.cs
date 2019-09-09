using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Security.Claims;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class UserClaimsRepository
    {


        /// <summary>
        /// Returns a ClaimsIdentity instance given a userId
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public ClaimsIdentity FindByUserId(long UserId)
        {
            ClaimsIdentity claims = new ClaimsIdentity();
            try
            {

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    foreach (var c in Db.Query("Select * from userclaims where UserId=@UserId", new { UserId = UserId }))
                    {
                        claims.AddClaim(new Claim(c.ClaimType, c.ClaimValue));
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return claims;
        }

        /// <summary>
        /// Deletes all claims from a user given a userId
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public void Delete(long UserId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Delete from userclaims where UserId = @UserId", new { UserId = UserId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Inserts a new claim in UserClaims table
        /// </summary>
        /// <param name="UserClaims">User's claim to be added</param>
        /// <param name="userId">User's id</param>
        /// <returns></returns>
        public void Insert(Claim UserClaims, long UserId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Insert into userclaims (ClaimValue, ClaimType, UserId) 
                values (@value, @type, @userId)",
                        new
                        {
                            value = UserClaims.Value,
                            type = UserClaims.Type,
                            userId = UserId
                        });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Deletes a claim from a user
        /// </summary>
        /// <param name="user">The user to have a claim deleted</param>
        /// <param name="claim">A claim to be deleted from user</param>
        /// <returns></returns>
        public void Delete(User user, Claim claim)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Delete from userclaims 
            where UserId = @UserId and @ClaimValue = @value and ClaimType = @type",
                    new
                    {
                        UserId = user.Id,
                        ClaimValue = claim.Value,
                        type = claim.Type
                    });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }
}
