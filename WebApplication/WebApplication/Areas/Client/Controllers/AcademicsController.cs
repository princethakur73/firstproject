using System.Linq;
using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.EnumHelper;
using WebApplication.Infrastructure;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class AcademicsController : Controller
    {
        private IPageService _pageService;
        private IFileService _datesheetService;
        public AcademicsController(IPageService pageService, IFileService datesheetService)
        {
            _pageService = pageService;
            _datesheetService = datesheetService;
        }

        [Route("datesheet")]
        public ActionResult DateSheet(int? id)
        {
            FileTypeModel model = new FileTypeModel();
            try
            {
                var list = _datesheetService.GetList(1, 20,(int)FiletypeEnum.Datesheet);
                if (list.Any())
                {
                    ViewBag.dd = list.Where(a => a.IsActive).Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Session.ToString("MMM yyy") }).ToList();
                    if(id.HasValue)
                    model = _datesheetService.GetById((int)id,0).ToModel();
                }
            }
            catch (System.Exception ex)
            {
                return View("~/Areas/Client/Views/Academics/DateSheet.cshtml", model);
            }
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