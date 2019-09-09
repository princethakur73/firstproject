using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class AcademicsController : Controller
    {
        private IPageService _pageService;
        public AcademicsController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [Route("datesheet")]
        public ActionResult DateSheet()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.DateSheet).ToModel();

            return View("~/Areas/Client/Views/Academics/DateSheet.cshtml", model);
        }

        [Route("result")]
        public ActionResult Result()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.Result).ToModel();

            return View("~/Areas/Client/Views/Academics/Result.cshtml", model);
        }

        [Route("schedule")]
        public ActionResult Schedule()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.Schedule).ToModel();

            return View("~/Areas/Client/Views/Academics/Schedule.cshtml", model);
        }
    }
}