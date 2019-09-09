using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class UserRepository : IUserRepository
    {
        private string query { get; set; }


        /// <summary>
        /// Returns the User's name given a User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetUserName(long UserId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<string>("Select Name from user where Id=@UserId", new { UserId = UserId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Returns a User ID given a User name
        /// </summary>
        /// <param name="userName">The User's name</param>
        /// <returns></returns>
        public long GetUserId(string userName)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<long>("Select Id from user where UserName=@UserName", new { UserName = userName });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Returns an TUser given the User's id
        /// </summary>
        /// <param name="UserId">The User's id</param>
        /// <returns></returns>
        public User GetUserById(long UserId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.Query<User>("Select * from user where Id=@UserId", new { UserId = UserId })
                    .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns a list of TUser instances given a User name
        /// </summary>
        /// <param name="userName">User's name</param>
        /// <returns></returns>
        public List<User> GetUserByName(string userName)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.Query<User>("Select * from user where UserName=@UserName", new { UserName = userName })
                    .ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<User> GetUserByEmail(string email)
        {
            return null;
        }

        /// <summary>
        /// Return the User's password hash
        /// </summary>
        /// <param name="UserId">The User's id</param>
        /// <returns></returns>
        public string GetPasswordHash(long UserId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<string>("Select PasswordHash from user where Id = @UserId", new { UserId = UserId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Sets the User's password hash
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public void SetPasswordHash(long UserId, string passwordHash)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"
                    UPDATE
                        user
                    SET
                        PasswordHash = @pwdHash
                    WHERE
                        Id = @Id", new { pwdHash = passwordHash, Id = UserId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Returns the User's security stamp
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string GetSecurityStamp(long UserId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<string>("Select SecurityStamp from user where Id = @UserId", new { UserId = UserId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Inserts a new User in the Users table
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public void Insert(User User)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("firstName", User.FirstName, System.Data.DbType.String);
                param.Add("lastName", User.LastName, System.Data.DbType.String);
                param.Add("dateOfBirth", User.DateOfBirth, System.Data.DbType.Date);
                param.Add("name", User.Name, System.Data.DbType.String);
                param.Add("pwdHash", User.PasswordHash, System.Data.DbType.String);
                param.Add("SecStamp", User.SecurityStamp, System.Data.DbType.String);
                param.Add("email", User.Email, System.Data.DbType.String);
                param.Add("emailconfirmed", User.EmailConfirmed, System.Data.DbType.Boolean);
                param.Add("MobileNo", User.MobileNo, System.Data.DbType.String);
                param.Add("MobileNoconfirmed", User.MobileNoConfirmed, System.Data.DbType.Boolean);
                param.Add("accesscount", User.AccessFailedCount, System.Data.DbType.Int32);
                param.Add("lockoutenabled", User.LockoutEnabled, System.Data.DbType.Boolean);
                param.Add("lockoutenddate", User.LockoutEndDateUtc, System.Data.DbType.DateTime);
                param.Add("twofactorenabled", User.TwoFactorEnabled, System.Data.DbType.Boolean);
                param.Add("masterPassword", User.MasterPassword, System.Data.DbType.String);

                query = @"Insert into user (FirstName,
                                            LastName,
                                            Name,
                                            DateOfBirth,
                                            UserName,
                                            PasswordHash, 
                                            SecurityStamp,
                                            MasterPassword,
                                            Email,
                                            EmailConfirmed,
                                            MobileNo,
                                            MobileNoConfirmed, 
                                            AccessFailedCount,
                                            LockoutEnabled,
                                            LockoutEndDateUtc,
                                            TwoFactorEnabled)
                                            values  
                                            (@firstName,
                                             @lastName,
                                             @name, 
                                             @dateOfBirth,
                                             @name,
                                             @pwdHash, 
                                             @SecStamp,
                                             @masterPassword,
                                             @email,
                                             @emailconfirmed,
                                             @MobileNo,
                                             @MobileNoconfirmed,
                                             @accesscount,
                                             @lockoutenabled,
                                             @lockoutenddate,
                                             @twofactorenabled);
                                SELECT LAST_INSERT_ID()";

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var id = Db.ExecuteScalar<long>(query, param);
                    // we need to set the id to the returned identity generated from the db
                    User.Id = id;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Updates a User in the Users table
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public void Update(User User)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"
                            Update user set FirstName=@firstName,LastName=@lastName,DateOfBirth=@dateOfBirth, UserName = @userName, PasswordHash = @pswHash, SecurityStamp = @secStamp, 
                Email=@email, EmailConfirmed=@emailconfirmed, MobileNo=@MobileNo, MobileNoConfirmed=@MobileNoconfirmed,
                AccessFailedCount=@accesscount, LockoutEnabled=@lockoutenabled, LockoutEndDateUtc=@lockoutenddate, TwoFactorEnabled=@twofactorenabled  
                WHERE Id = @UserId",
                    new
                    {
                        firstName = User.FirstName,
                        lastName = User.LastName,
                        dateOfBirth = User.DateOfBirth,
                        userName = User.UserName,
                        pswHash = User.PasswordHash,
                        secStamp = User.SecurityStamp,
                        UserId = User.Id,
                        email = User.Email,
                        emailconfirmed = User.EmailConfirmed,
                        MobileNo = User.MobileNo,
                        MobileNoconfirmed = User.MobileNoConfirmed,
                        accesscount = User.AccessFailedCount,
                        lockoutenabled = User.LockoutEnabled,
                        lockoutenddate = User.LockoutEndDateUtc,
                        twofactorenabled = User.TwoFactorEnabled
                    }
               );
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        #region Get List
        public async Task<IEnumerable<User>> GetListAsync(long currentUserId)
        {
            IEnumerable<User> result = new List<User>();
            try
            {
                query = @"SELECT *
                        FROM user
						where CreateByUserId=@currentUserId 
							";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = await Db.QueryAsync<User>(query, param: new { currentUserId = currentUserId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<User> GetAll(long currentUserId)
        {
            List<User> result = new List<User>();
            try
            {
                query = @"SELECT *
                        FROM user
						where CreateByUserId=@currentUserId
							";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = Db.Query<User>(query, param: new { currentUserId = currentUserId }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }
        #endregion

        #region Delete
        public bool DeleteById(long Id)
        {
            bool result = false;
            try
            {
                query = @"delete from user where Id = @Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = Db.ExecuteScalar<bool>(query, new { Id = Id });
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool DeleteById(User obj, long currentUserId)
        {
            bool result = false;
            try
            {
                query = @"delete from user where Id = @Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(query, new { Id = obj.Id });
                }
                result = true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<bool> DeleteByIdAsync(long Id, long currentUserId)
        {
            bool result = false;
            try
            {
                query = @"delete from user where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    await Db.ExecuteAsync(query, new { Id = Id });
                }
                result = true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<bool> DeleteByIdAsync(User obj, long currentUserId)
        {
            bool result = false;
            try
            {
                query = @"delete from user where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    await Db.ExecuteAsync(query, new { Id = obj.Id });
                }
                result = true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }
        #endregion

        #region Get By Id
        public User GetById(long Id)
        {
            User result = new User();
            try
            {
                query = @"SELECT *
                        FROM user
						where Id=@Id 
							";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = Db.Query<User>(query, param: new { Id = Id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public User GetById(User obj, long currentUserId)
        {
            User result = new User();
            try
            {
                query = @"SELECT *
                        FROM user
						where Id=@Id 
							";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = Db.Query<User>(query, param: new { Id = obj.Id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<User> GetByIdAsync(long Id, long currentUserId)
        {
            User result;
            try
            {
                query = @"SELECT *
                        FROM user
						where Id=@Id d
							";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = (await Db.QueryAsync<User>(query, param: new { Id = Id })).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<User> GetByIdAsync(User obj, long currentUserId)
        {
            User result = new User();
            try
            {
                query = @"SELECT *
                        FROM user
						where Id=@Id 
							";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = (await Db.QueryAsync<User>(query, param: new { Id = obj.Id })).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        #endregion

        #region Save
        public async Task<User> SaveAsync(User obj)
        {
            User result = new User();
            try
            {
                if (obj.Id == 0)
                {
                    query = @"INSERT INTO `user`
                                (`Name`,
                                `DateOfBirth`,
                                `MobileNo`,
                                `MobileNoConfirmed`,
                                `Email`,
                                `EmailConfirmed`,
                                `UserName`,
                                `PasswordHash`,
                                `SecurityStamp`,
                                `TwoFactorEnabled`,
                                `LockoutEndDateUtc`,
                                `LockoutEnabled`,
                                `AccessFailedCount`,
                                `CreateByUserId`,
						        `CreateByDate`,
						        `ModifyByUserId`,
						        `ModifyByDate`)
                                VALUES
                                (@Name,
                                @DateOfBirth,
                                @MobileNo,
                                @MobileNoConfirmed,
                                @Email,
                                @EmailConfirmed,
                                @UserName,
                                @PasswordHash,
                                @SecurityStamp,
                                @TwoFactorEnabled,
                                @LockoutEndDateUtc,
                                @LockoutEnabled,
                                @AccessFailedCount,
                                @CreateByUserId,
						        @CreateByDate,
						        @ModifyByUserId,
						        @ModifyByDate);
                                SELECT LAST_INSERT_ID()
						";
                }
                else
                {
                    query = @"UPDATE user
                                    SET
                                    `Name` = @Name,
                                    `DateOfBirth` = @DateOfBirth,
                                    `MobileNo` = @MobileNo,
                                    `MobileNoConfirmed` = @MobileNoConfirmed,
                                    `Email` = @Email,
                                    `EmailConfirmed` = @EmailConfirmed,
                                    `UserName` = @UserName,
                                    `PasswordHash` = @PasswordHash,
                                    `SecurityStamp` = @SecurityStamp,
                                    `TwoFactorEnabled` = @TwoFactorEnabled,
                                    `LockoutEndDateUtc` = @LockoutEndDateUtc,
                                    `LockoutEnabled` = @LockoutEnabled,
                                    `AccessFailedCount` = @AccessFailedCount,
                                    `ModifyByUserId` = @ModifyByUserId,
							        `ModifyByDate` = @ModifyByDate
                                    WHERE `Id` = @Id;

										";
                }
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = await Db.ExecuteScalarAsync<User>(query, obj);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public int Save(User obj)
        {
            int result = 0;
            try
            {
                if (obj.Id == 0)
                {
                    query = @"INSERT INTO `user`
                                (`Name`,
                                `DateOfBirth`,
                                `MobileNo`,
                                `MobileNoConfirmed`,
                                `Email`,
                                `EmailConfirmed`,
                                `UserName`,
                                `PasswordHash`,
                                `SecurityStamp`,
                                `TwoFactorEnabled`,
                                `LockoutEndDateUtc`,
                                `LockoutEnabled`,
                                `AccessFailedCount`,
                                `CreateByUserId`,
						        `CreateByDate`,
						        `ModifyByUserId`,
						        `ModifyByDate`)
                                VALUES
                                (@Name,
                                @DateOfBirth,
                                @MobileNo,
                                @MobileNoConfirmed,
                                @Email,
                                @EmailConfirmed,
                                @UserName,
                                @PasswordHash,
                                @SecurityStamp,
                                @TwoFactorEnabled,
                                @LockoutEndDateUtc,
                                @LockoutEnabled,
                                @AccessFailedCount,
                                @CreateByUserId,
						        @CreateByDate,
						        @ModifyByUserId,
						        @ModifyByDate);
                            SELECT LAST_INSERT_ID()
						";
                }
                else
                {
                    query = @"UPDATE user
                                    SET
                                    `Name` = @Name,
                                    `DateOfBirth` = @DateOfBirth,
                                    `MobileNo` = @MobileNo,
                                    `MobileNoConfirmed` = @MobileNoConfirmed,
                                    `Email` = @Email,
                                    `EmailConfirmed` = @EmailConfirmed,
                                    `UserName` = @UserName,
                                    `PasswordHash` = @PasswordHash,
                                    `SecurityStamp` = @SecurityStamp,
                                    `TwoFactorEnabled` = @TwoFactorEnabled,
                                    `LockoutEndDateUtc` = @LockoutEndDateUtc,
                                    `LockoutEnabled` = @LockoutEnabled,
                                    `AccessFailedCount` = @AccessFailedCount,
                                    `ModifyByUserId` = @ModifyByUserId,
							        `ModifyByDate` = @ModifyByDate
                                    WHERE `Id` = @Id;

										";
                }
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    result = Db.Execute(query, obj);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
