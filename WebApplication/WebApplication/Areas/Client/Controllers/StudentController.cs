using System.Linq;
using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class StudentController : Controller
    {
        private IPageService _pageService;
        private IDownloadsService _downloadsService;
        private ITransferCertificateService _transferCertificateService;
        public StudentController(IPageService pageService,
            IDownloadsService downloadsService, ITransferCertificateService transferCertificateService)
        {
            _downloadsService = downloadsService;
            _pageService = pageService;
            _transferCertificateService = transferCertificateService;
        }
        [Route("sports")]
        public ActionResult Sports()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.Sports).ToModel();

            return View("~/Areas/Client/Views/Student/Sports.cshtml", model);
        }

        [Route("activities")]
        public ActionResult ActivitiesEvents()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.ActivitiesEvents).ToModel();

            return View("~/Areas/Client/Views/Student/ActivitiesEvents.cshtml", model);
        }

        [Route("on-roll")]
        public ActionResult OnRoll()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.OnRollStudents).ToModel();

            return View(@"~/Areas/Client/Views/Student/OnRoll.cshtml", model);
        }

        [Route("transfer-certificate")]
        public ActionResult TransferCertificate()
        {
            //var model = _pageService.GetPageByMenuCode(MenuCode.TransferCertificate).ToModel();
            var model = _transferCertificateService.GetList().ToModel();

            return View("~/Areas/Client/Views/Student/TransferCertificate.cshtml", model);
        }

        [Route("download")]
        public ActionResult Download()
        {
            var model = _downloadsService.GetList(currentUserId: 0).Where(m => m.IsPublish == true).ToList().ToModel();

            return View("~/Areas/Client/Views/Student/Download.cshtml", model);
        }
    }
}