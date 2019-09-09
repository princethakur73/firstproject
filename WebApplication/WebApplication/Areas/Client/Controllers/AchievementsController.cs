using System.Web.Mvc;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly IToppersService _toppersService;

        public AchievementsController(IToppersService toppersService)
        {
            _toppersService = toppersService;
        }
        [Route("ours-toppers")]
        public ActionResult OursToppers()
        {
            var dataList = _toppersService.GetList(currentUserId: 0).ToModel();
            return View("~/Areas/Client/Views/Achievements/OursToppers.cshtml", dataList);
        }
    }
}