using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Infrastructure;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly IToppersService _toppersService;
        private readonly IPageService _pageService;
        private readonly ICurrentUser _currentUser;

        public AchievementsController(IToppersService toppersService, IPageService pageService, ICurrentUser currentUser)
        {
            _toppersService = toppersService;
            _pageService = pageService;
            _currentUser = currentUser;
        }
        [Route("ours-toppers")]
        public ActionResult OursToppers()
        {
            var dataList = _toppersService.GetList(currentUserId: 0).ToModel();
            return View("~/Areas/Client/Views/Achievements/OursToppers.cshtml", dataList);
        }
        [Route("inter-school-prizes")]
        public ActionResult InterSchoolPrizes()
        {
            var dataList = _pageService.GetPageByMenuCode(MenuCode.InterSchoolPrizes).ToModel();
            return View("~/Areas/Client/Views/Achievements/InterSchoolPrizes.cshtml", dataList);
        }
        [Route("hub-learning-activities")]
        public ActionResult HubLearningActivities()
        {
            var dataList = _pageService.GetPageByMenuCode(MenuCode.HubLearningActivities).ToModel();
            return View("~/Areas/Client/Views/Achievements/HubLearningActivities.cshtml", dataList);
        }
    }
}