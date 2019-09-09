using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Core;

namespace WebApplication
{
    // You can add profile data for the AppMember by adding more properties to your AppMember class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, long> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom AppMember claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// Create and opens a connection to a MSSql database
    /// </summary>

    public class ApplicationDbContext : IDisposable
    {
        public ApplicationDbContext(string connectionName)

        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(ConfigurationManager.ConnectionStrings["HvmSchool"].ConnectionString);
        }

        public void Dispose()
        {

        }
    }

    //public class ApplicationDbContext : IdentityDbContext<AppMember>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}