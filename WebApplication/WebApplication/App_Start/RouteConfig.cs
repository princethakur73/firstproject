using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Client",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication.Areas.Client.Controllers" }
            );

            routes.MapRoute(
            name: "Admin",
            url: "admin/{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "DashboardV2", id = UrlParameter.Optional },
            namespaces: new[] { "WebApplication.Areas.Admin.Controllers" }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            //  routes.MapRoute(
            //    name: "Login",
            //    url: "admin-login",
            //    defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            //);
        }
    }
}
