using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class AdmissionController : Controller
    {
        private IPageService _pageService;
        public AdmissionController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [Route("admission-rule")]
        public ActionResult AdmissionRule()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.AdmissionRules).ToModel();

            return View("~/Areas/Client/Views/Admission/AdmissionRule.cshtml", model);
        }

        [Route("fee-structure")]
        public ActionResult FeeStructure()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.FeeStructure).ToModel();

            return View("~/Areas/Client/Views/Admission/FeeStructure.cshtml", model);
        }
    }
}