using WebApplication.Core;
using WebApplication.Service.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using StructureMap.Configuration.DSL;
using System.Web;

namespace WebApplication.Infrastructure
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.Assembly("WebApplication.Service");
                scan.WithDefaultConventions();
            });

            For<IUserStore<User, long>>().Use<UserService>();
            For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);
        }
    }
}