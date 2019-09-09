using System.Collections.Generic;
using WebApplication.Core;
namespace WebApplication.Repository
{
    public interface IUserRepository : IRepository<User>
    {

        /// <summary>
        /// Returns the User's name given a User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        string GetUserName(long UserId);

        /// <summary>
        /// Returns a User ID given a User name
        /// </summary>
        /// <param name="userName">The User's name</param>
        /// <returns></returns>
        long GetUserId(string userName);


        /// <summary>
        /// Returns an User given the User's id
        /// </summary>
        /// <param name="UserId">The User's id</param>
        /// <returns></returns>
        User GetUserById(long UserId);

        /// <summary>
        /// Returns a list of User instances given a User name
        /// </summary>
        /// <param name="userName">User's name</param>
        /// <returns></returns>
        List<User> GetUserByName(string userName);

        /// <summary>
        /// Returns a list of User instances given a Email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns></returns>
        List<User> GetUserByEmail(string email);

        /// <summary>
        /// Return the User's password hash
        /// </summary>
        /// <param name="UserId">The User's id</param>
        /// <returns></returns>
        string GetPasswordHash(long UserId);

        /// <summary>
        /// Sets the User's password hash
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        void SetPasswordHash(long UserId, string passwordHash);

        /// <summary>
        /// Returns the User's security stamp
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        string GetSecurityStamp(long UserId);

        /// <summary>
        /// Inserts a new User in the Users table
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        void Insert(User User);

        /// <summary>
        /// Updates a User in the Users table
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        void Update(User User);

        User GetById(long id);

        bool DeleteById(long id);
    }
}
