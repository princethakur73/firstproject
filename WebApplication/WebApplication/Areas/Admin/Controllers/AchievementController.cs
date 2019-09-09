using System.Web.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class AchievementController : Controller
    {
        public ActionResult OursToppers()
        {
            return View();
        }
    }
}