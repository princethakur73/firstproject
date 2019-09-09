using Microsoft.Web.Mvc;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ActionResult RedirectToAction<TController>(
                 Expression<Action<TController>> action) where TController : Controller
        {
            return ControllerExtensions.RedirectToAction(this, action);
        }
    }
}