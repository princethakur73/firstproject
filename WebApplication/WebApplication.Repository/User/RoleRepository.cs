using Dapper;
using MySql.Data.MySqlClient;
using System;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class RoleRepository
    {

        /// <summary>
        /// Deltes a role from the Roles table
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns></returns>
        public void Delete(int roleId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Delete from roles where Id = @id", new { id = roleId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Inserts a new Role in the Roles table
        /// </summary>
        /// <param name="roleName">The role's name</param>
        /// <returns></returns>
        public void Insert(Role role)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"Insert into roles (Name) values (@name)",
                    new { name = role.Name });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns a role name given the roleId
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns>Role name</returns>
        public string GetRoleName(int roleId)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<string>("Select Name from roles where Id=@id", new { id = roleId });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns the role Id given a role name
        /// </summary>
        /// <param name="roleName">Role's name</param>
        /// <returns>Role's Id</returns>
        public int GetRoleId(string roleName)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<int>("Select Id from roles where Name=@name", new { name = roleName });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the IdentityRole given the role Id
        /// </summary>
        /// <param name="roleI"></param>
        /// <returns></returns>
        public Role GetRoleById(int roleId)
        {
            var roleName = GetRoleName(roleId);
            Role role = null;
            try
            {

                if (roleName != null)
                {
                    role = new Role(roleName, roleId);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return role;
        }

        /// <summary>
        /// Gets the IdentityRole given the role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public Role GetRoleByName(string roleName)
        {
            Role role = null;
            try
            {
                var roleId = GetRoleId(roleName);


                if (roleId > 0)
                {
                    role = new Role(roleName, roleId);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return role;
        }

        public void Update(Role role)
        {
            try
            {
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Db.Execute(@"
                    UPDATE roles
                    SET
                        Name = @name
                    WHERE
                        Id = @id",
                        new
                        {
                            name = role.Name,
                            id = role.Id
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
