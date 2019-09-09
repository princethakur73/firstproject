using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service.Services
{
    public class UserService : IUserService, IUserLoginStore<User, long>,
        IUserClaimStore<User, long>,
        IUserRoleStore<User, long>,
        IUserPasswordStore<User, long>,
        IUserSecurityStampStore<User, long>,
        IQueryableUserStore<User, long>,
        IUserEmailStore<User, long>,
        IUserPhoneNumberStore<User, long>,
        IUserTwoFactorStore<User, long>,
        IUserLockoutStore<User, long>
    //,IUserStore<User, long>
    {
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private UserRolesRepository userRolesRepository;
        private UserClaimsRepository userClaimsRepository;
        private UserLoginsRepository userLoginsRepository;
        public IQueryable<User> Users
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Constructor that takes a dbmanager as argument
        /// </summary>
        /// <param name="database"></param>
        public UserService()
        {
            userRepository = new UserRepository();
            roleRepository = new RoleRepository();
            userRolesRepository = new UserRolesRepository();
            userClaimsRepository = new UserClaimsRepository();
            userLoginsRepository = new UserLoginsRepository();
        }

        /// <summary>
        /// Insert a new TUser in the UserRepository
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task CreateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            userRepository.Insert(user);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Returns an TUser instance based on a userId query
        /// </summary>
        /// <param name="userId">The user's Id</param>
        /// <returns></returns>
        public Task<User> FindByIdAsync(long userId)
        {
            //if (string.IsNullOrEmpty(userId))
            //{
            //    throw new ArgumentException("Null or empty argument: userId");
            //}

            User result = userRepository.GetUserById(userId) as User;
            if (result != null)
            {
                return Task.FromResult<User>(result);
            }

            return Task.FromResult<User>(null);
        }

        /// <summary>
        /// Returns an TUser instance based on a userName query
        /// </summary>
        /// <param name="userName">The user's name</param>
        /// <returns></returns>
        public Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Null or empty argument: userName");
            }

            List<User> result = userRepository.GetUserByName(userName) as List<User>;

            // Should I throw if > 1 user?
            if (result != null && result.Count == 1)
            {
                return Task.FromResult<User>(result[0]);
            }

            return Task.FromResult<User>(null);
        }

        /// <summary>
        /// Updates the UsersRepository with the TUser instance values
        /// </summary>
        /// <param name="user">TUser to be updated</param>
        /// <returns></returns>
        public Task UpdateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            userRepository.Update(user);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Inserts a claim to the UserClaimsRepository for the given user
        /// </summary>
        /// <param name="user">User to have claim added</param>
        /// <param name="claim">Claim to be added</param>
        /// <returns></returns>
        public Task AddClaimAsync(User user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("user");
            }

            userClaimsRepository.Insert(claim, user.Id);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Returns all claims for a given user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<IList<Claim>> GetClaimsAsync(User user)
        {
            ClaimsIdentity identity = userClaimsRepository.FindByUserId(user.Id);

            return Task.FromResult<IList<Claim>>(identity.Claims.ToList());
        }

        /// <summary>
        /// Removes a claim froma user
        /// </summary>
        /// <param name="user">User to have claim removed</param>
        /// <param name="claim">Claim to be removed</param>
        /// <returns></returns>
        public Task RemoveClaimAsync(User user, Claim claim)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            userClaimsRepository.Delete(user, claim);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Inserts a Login in the UserLoginsRepository for a given User
        /// </summary>
        /// <param name="user">User to have login added</param>
        /// <param name="login">Login to be added</param>
        /// <returns></returns>
        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            userLoginsRepository.Insert(user, login);

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Returns an TUser based on the Login info
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Task<User> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            var userId = userLoginsRepository.FindUserIdByLogin(login);
            if (userId > 0)
            {
                User user = userRepository.GetUserById(userId) as User;
                if (user != null)
                {
                    return Task.FromResult<User>(user);
                }
            }

            return Task.FromResult<User>(null);
        }

        /// <summary>
        /// Returns list of UserLoginInfo for a given TUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            List<UserLoginInfo> userLogins = new List<UserLoginInfo>();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<UserLoginInfo> logins = userLoginsRepository.FindByUserId(user.Id);
            if (logins != null)
            {
                return Task.FromResult<IList<UserLoginInfo>>(logins);
            }

            return Task.FromResult<IList<UserLoginInfo>>(null);
        }

        /// <summary>
        /// Deletes a login from UserLoginsRepository for a given TUser
        /// </summary>
        /// <param name="user">User to have login removed</param>
        /// <param name="login">Login to be removed</param>
        /// <returns></returns>
        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            userLoginsRepository.Delete(user, login);

            return Task.FromResult<Object>(null);
        }

        /// <summary>
        /// Inserts a entry in the UserRoles Repository
        /// </summary>
        /// <param name="user">User to have role added</param>
        /// <param name="roleName">Name of the role to be added to user</param>
        /// <returns></returns>
        public Task AddToRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("Argument cannot be null or empty: roleName.");
            }

            int roleId = roleRepository.GetRoleId(roleName);
            if (roleId > 0)
            {
                userRolesRepository.Insert(user, roleId);
            }
            //if (!string.IsNullOrEmpty(roleId))
            //{
            //    userRolesRepository.Insert(user, roleId);
            //}

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Returns the roles for a given TUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<IList<string>> GetRolesAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            List<string> roles = userRolesRepository.FindByUserId(user.Id);
            {
                if (roles != null)
                {
                    return Task.FromResult<IList<string>>(roles);
                }
            }

            return Task.FromResult<IList<string>>(null);
        }

        /// <summary>
        /// Verifies if a user is in a role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public Task<bool> IsInRoleAsync(User user, string role)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentNullException("role");
            }

            List<string> roles = userRolesRepository.FindByUserId(user.Id);
            {
                if (roles != null && roles.Contains(role))
                {
                    return Task.FromResult<bool>(true);
                }
            }

            return Task.FromResult<bool>(false);
        }

        /// <summary>
        /// Removes a user from a role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public Task RemoveFromRoleAsync(User user, string role)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task DeleteAsync(User user)
        {
            if (user != null)
            {
                userRepository.DeleteById(user, 0);
            }

            return Task.FromResult<Object>(null);
        }

        /// <summary>
        /// Returns the PasswordHash for a given TUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetPasswordHashAsync(User user)
        {
            string passwordHash = userRepository.GetPasswordHash(user.Id);

            return Task.FromResult<string>(passwordHash);
        }

        /// <summary>
        /// Verifies if user has password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> HasPasswordAsync(User user)
        {
            var hasPassword = !string.IsNullOrEmpty(userRepository.GetPasswordHash(user.Id));

            return Task.FromResult<bool>(Boolean.Parse(hasPassword.ToString()));
        }

        /// <summary>
        /// Sets the password hash for a given TUser
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult<Object>(null);
        }

        /// <summary>
        ///  Set security stamp
        /// </summary>
        /// <param name="user"></param>
        /// <param name="stamp"></param>
        /// <returns></returns>
        public Task SetSecurityStampAsync(User user, string stamp)
        {
            user.SecurityStamp = stamp;

            return Task.FromResult(0);

        }

        /// <summary>
        /// Get security stamp
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetSecurityStampAsync(User user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        /// <summary>
        /// Set email on user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task SetEmailAsync(User user, string email)
        {
            user.Email = email;
            userRepository.Update(user);

            return Task.FromResult(0);

        }

        /// <summary>
        /// Get email from user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(user.Email);
        }

        /// <summary>
        /// Get if user email is confirmed
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        /// <summary>
        /// Set when user email is confirmed
        /// </summary>
        /// <param name="user"></param>
        /// <param name="confirmed"></param>
        /// <returns></returns>
        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<User> FindByEmailAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }

            User result = userRepository.GetUserByEmail(email).FirstOrDefault();
            if (result != null)
            {
                return Task.FromResult<User>(result);
            }

            return Task.FromResult<User>(null);
        }

        /// <summary>
        /// Set user phone number
        /// </summary>
        /// <param name="user"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            user.MobileNo = phoneNumber;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Get user phone number
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<string> GetPhoneNumberAsync(User user)
        {
            return Task.FromResult(user.MobileNo);
        }

        /// <summary>
        /// Get if user phone number is confirmed
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetPhoneNumberConfirmedAsync(User user)
        {
            return Task.FromResult(user.MobileNoConfirmed);
        }

        /// <summary>
        /// Set phone number if confirmed
        /// </summary>
        /// <param name="user"></param>
        /// <param name="confirmed"></param>
        /// <returns></returns>
        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            user.MobileNoConfirmed = confirmed;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Set two factor authentication is enabled on the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Get if two factor authentication is enabled on the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        /// <summary>
        /// Get user lock out end date
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return
                Task.FromResult(user.LockoutEndDateUtc.HasValue
                    ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                    : new DateTimeOffset());
        }

        /// <summary>
        /// Set user lockout end date
        /// </summary>
        /// <param name="user"></param>
        /// <param name="lockoutEnd"></param>
        /// <returns></returns>
        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            user.LockoutEndDateUtc = lockoutEnd.UtcDateTime;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Increment failed access count
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            user.AccessFailedCount++;
            userRepository.Update(user);

            return Task.FromResult(user.AccessFailedCount);
        }

        /// <summary>
        /// Reset failed access count
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task ResetAccessFailedCountAsync(User user)
        {
            user.AccessFailedCount = 0;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        /// <summary>
        /// Get failed access count
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        /// <summary>
        /// Get if lockout is enabled for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        /// <summary>
        /// Set lockout enabled for user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            userRepository.Update(user);

            return Task.FromResult(0);
        }

        #region Delete
        public bool DeleteById(long Id, long currentUserId)
        {
            bool result = false;
            try
            {
                userRepository.DeleteById(Id);
                result = true;
            }
            catch (SqlException ex)
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
                userRepository.DeleteById(obj.Id);
                result = true;
            }
            catch (SqlException ex)
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
                await userRepository.DeleteByIdAsync(Id, currentUserId);
                result = true;
            }
            catch (SqlException ex)
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
                await userRepository.DeleteByIdAsync(obj.Id, currentUserId);
                result = true;
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        #endregion

        #region Get By Id
        public User GetById(long Id, long currentUserId)
        {
            User User = new User();
            try
            {
                User = userRepository.GetById(Id);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return User;
        }

        public User GetById(User obj, long currentUserId)
        {
            User User = new User();
            try
            {
                User = userRepository.GetById(obj.Id);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return User;
        }

        public async Task<User> GetByIdAsync(long Id, long currentUserId)
        {
            User User = new User();
            try
            {
                User = await userRepository.GetByIdAsync(Id, currentUserId);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return User;
        }

        public async Task<User> GetByIdAsync(User obj, long currentUserId)
        {
            User User = new User();
            try
            {
                User = await userRepository.GetByIdAsync(obj.Id, currentUserId);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return User;
        }
        #endregion

        #region Get By List
        public List<User> GetList(long currentUserId)
        {
            List<User> Users = new List<User>();
            try
            {
                Users = userRepository.GetAll(currentUserId);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return Users;
        }

        public async Task<IEnumerable<User>> GetListAsync(long currentUserId)
        {
            IEnumerable<User> Users;
            try
            {
                Users = await userRepository.GetListAsync(currentUserId);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return Users;
        }
        #endregion

        #region Save
        public long Save(User obj)
        {
            long User = 0;
            try
            {
                User = userRepository.Save(obj);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return User;
        }

        public async Task<User> SaveAsync(User obj)
        {
            User User = new User();
            try
            {
                User = await userRepository.SaveAsync(obj);

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return User;
        }
        #endregion

        public void Dispose()
        {
            if (userRepository != null)
            {
                userRepository = null;
            }
        }
    }
}
