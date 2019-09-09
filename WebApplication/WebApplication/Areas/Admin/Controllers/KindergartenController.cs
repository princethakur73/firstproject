using System.Web.Mvc;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class KindergartenController : Controller
    {
        // GET: Admin/Kindergarten
        public ActionResult Index()
        {
            return View();
        }
    }
}