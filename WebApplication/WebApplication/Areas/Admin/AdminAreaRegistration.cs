﻿using System.Web.Mvc;

namespace WebApplication.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                 "Admin_default",
                 "Admin/{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "WebApplication.Areas.Admin.Controllers" }
             );
            context.MapRoute(
               "Admin_Login",
               "Admin",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional },
           namespaces: new[] { "WebApplication.Areas.Admin.Controllers" }
           );

            //   context.MapRoute(
            //    name: "LogOff",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}