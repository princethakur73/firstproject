using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.EnumHelper;
using WebApplication.Infrastructure;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{

    public class CircularsController : WebApplicationController
    {
        private readonly IPageService _pageService;
        private IDownloadsService _downloadsService;
        private ICircularsService _circularsService;
        private ICurrentUser _currentUser;
        private IFileService _fileService;
        private readonly ICommonService _commonService;
        public CircularsController(IPageService pageService, IDownloadsService downloadsService, ICircularsService circularsService, ICurrentUser currentUser, IFileService fileService, ICommonService commonService)
        {
            _pageService = pageService;
            _downloadsService = downloadsService;
            _circularsService = circularsService;
            _currentUser = currentUser;
            _fileService = fileService;
            _commonService = commonService;
        }
        // GET: Client/Circulars

        public ActionResult Index()
        {
            return View();
        }
        [Route("time-table")]
        public ActionResult TimeTable()
        {
            FileTypeModel model = new FileTypeModel();
            try
            {
                model = _fileService.GetList(1, 20,(int)FiletypeEnum.Timetable).FirstOrDefault().ToModel();
            }
            catch (Exception ex)
            {
                return View("~/Areas/Client/Views/Circulars/TimeTable.cshtml", model);
            }
            return View("~/Areas/Client/Views/Circulars/TimeTable.cshtml", model);
        }
        [Route("evaluation-weightage")]
        public ActionResult EvaluationWeightage()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.EvaluationWeightage).ToModel();
            return View("~/Areas/Client/Views/Circulars/EvaluationWeightage.cshtml", model);
        }
        [Route("school-diary")]
        public ActionResult SchoolDiary()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.SchoolDiary).ToModel();
            return View("~/Areas/Client/Views/Circulars/SchoolDiary.cshtml", model);
        }
        [Route("code-of-conduct-for-student")]
        public ActionResult CodeOfConductForStudent()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.CodeOfConductForStudent).ToModel();
            return View("~/Areas/Client/Views/Circulars/CodeOfConductForStudent.cshtml", model);
        }
        [Route("list-of-books")]
        public ActionResult ListOfBooks()
        {
            var model = _downloadsService.GetList(currentUserId: 0).Where(m => m.IsPublish && m.Title.ToLower().Contains("book list")).ToList().ToModel();
            return View("~/Areas/Client/Views/Circulars/ListOfBooks.cshtml", model);
        }
        [Route("list-of-Holidays")]
        public ActionResult ListOfHolidays()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.ListOfHolidays).ToModel();
            return View("~/Areas/Client/Views/Circulars/ListOfHolidays.cshtml", model);
        }
        [Route("teaching-methodology")]
        public ActionResult TeachingMethodology()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.TeachingMethodology).ToModel();
            return View("~/Areas/Client/Views/Circulars/TeachingMethodology.cshtml", model);
        }
        [Route("smart-learning")]
        public ActionResult SmartLearning()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.SmartLearning).ToModel();
            return View("~/Areas/Client/Views/Circulars/SmartLearning.cshtml", model);
        }
        [Route("syllabus")]
        public ActionResult Syllabus()
        {
            //var model = _pageService.GetPageByMenuCode(MenuCode.Syllabus).ToModel();
            var model = _downloadsService.GetList(currentUserId: 0).Where(m => m.IsPublish && m.Title.ToLower().Contains("syllabus")).ToList().ToModel();
            return View("~/Areas/Client/Views/Circulars/Syllabus.cshtml", model);
        }
        [Route("ptm-schedule")]
        public ActionResult PTMSchedule()
        {
            var list = _circularsService.GetListPtm(1, 100);
            var model = list.ToModel();
            return View("~/Areas/Client/Views/Circulars/PTMSchedule.cshtml", model.Where(a => a.IsActive).ToList());
        }

        [Route("co-curricular-activites")]
        public ActionResult CoCurricularActivites()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.CoCurricularActivites).ToModel();
            return View("~/Areas/Client/Views/Circulars/CoCurricularActivites.cshtml", model);
        }

        [Route("school-circulars")]
        public ActionResult SchoolCirculars(string year)
        {            
            ViewBag.SessionList = _commonService.GetSessionList().Select(s => new SelectListItem { Value = s.Name, Text = s.Name }).ToList(); //drop down list
            ViewBag.SelectedYear = year; //selected year
            var model = _circularsService.GetList(year).ToModel();            
            return View("~/Areas/Client/Views/Circulars/SchoolCirculars.cshtml", model);
        }
    }
}