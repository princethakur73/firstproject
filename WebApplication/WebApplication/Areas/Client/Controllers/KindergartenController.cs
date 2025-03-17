using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class KindergartenController : Controller
    {
        private IPageService _pageService;
        public KindergartenController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [Route("kindergarten")]
        public ActionResult Kindergarten()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.Kindergarten).ToModel();
            return View("~/Areas/Client/Views/Kindergarten/Kindergarten.cshtml", model);
        }
    }
}