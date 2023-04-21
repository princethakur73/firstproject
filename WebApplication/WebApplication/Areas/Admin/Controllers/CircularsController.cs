using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Area.Admin.Models;
using WebApplication.Core.Common;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Alerts;
using WebApplication.Models;
using WebApplication.Service;
using WebApplication.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class CircularsController : WebApplicationController
    {
        private IPageService _pageService;
        private ICurrentUser _currentUser;
        private ICircularsService _circularsService;
        private IGalleryService _GalleryService;
        private readonly ICommonService _commonService;
        public CircularsController(IPageService pageService, ICurrentUser currentUser, ICircularsService circularsService, IGalleryService GalleryService, ICommonService commonService)
        {
            _pageService = pageService;
            _currentUser = currentUser;
            _circularsService = circularsService;
            _GalleryService = GalleryService;
            _commonService = commonService;
        }
        // GET: Admin/Circulars
        public ActionResult Index()
        {
            GalleryModel galleryModel = new GalleryModel();
            galleryModel.SessionId = _GalleryService.GetCurrentSession();
            return View(galleryModel);
        }
        public ActionResult EvaluationWeightage()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.EvaluationWeightage).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EvaluationWeightage(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.EvaluationWeightage;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.EvaluationWeightage(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.EvaluationWeightage(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult SchoolDiary()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.SchoolDiary).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SchoolDiary(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.SchoolDiary;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.SchoolDiary(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.SchoolDiary(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult CodeOfConductForStudent()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.CodeOfConductForStudent).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CodeOfConductForStudent(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.CodeOfConductForStudent;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.CodeOfConductForStudent(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.CodeOfConductForStudent(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult ListOfBooks()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.ListOfBooks).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListOfBooks(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.ListOfBooks;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.ListOfBooks(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.ListOfBooks(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult ListOfHolidays()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.ListOfHolidays).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListOfHolidays(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.ListOfHolidays;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.ListOfHolidays(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.ListOfHolidays(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult TeachingMethodology()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.TeachingMethodology).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeachingMethodology(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.TeachingMethodology;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.TeachingMethodology(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.TeachingMethodology(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult SmartLearning()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.SmartLearning).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SmartLearning(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.SmartLearning;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.SmartLearning(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.SmartLearning(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult Syllabus()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.Syllabus).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Syllabus(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.Syllabus;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.Syllabus(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.Syllabus(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PTMSchedule(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.PTMSchedule;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.PTMSchedule(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.PTMSchedule(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult CoCurricularActivites()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.CoCurricularActivites).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CoCurricularActivites(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.CoCurricularActivites;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.CoCurricularActivites(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.CoCurricularActivites(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SchoolCirculars(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.SchoolCirculars;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.CoCurricularActivites(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.CoCurricularActivites(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult SchoolCirculars()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.SchoolCirculars).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////

        public ActionResult Create()
        {
            return View(new CircularsModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CircularsModel model)
        {
            try
            {

                HttpPostedFileBase file = Request.Files["file"];

                if (file.ContentLength == 0)
                {
                    ModelState.AddModelError("FileName", "Please give valid file.");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string fileName = file.FileName;

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/circulars/"), fileName));

                        obj.FileName = fileName;
                        obj.Extenstion = Path.GetExtension(file.FileName);
                        model.FileName = fileName;
                    }

                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_circularsService.Save(obj) > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.Index())
                                        .WithSuccess("Saved Successfully!");
                }

                return View(model).WithError("Error occurred while saving record.");
            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }

        }

        public ActionResult Edit(int? Id)
        {
            CircularsModel model = new CircularsModel();
            try
            {
                model = _circularsService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<CircularsController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CircularsModel model)
        {
            try
            {

                HttpPostedFileBase file = Request.Files["file"];

                if (file.ContentLength == 0 && model.FileName == null)
                {
                    ModelState.AddModelError("FileName", "Please give valid file.");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/circulars/"), model.FileName)))
                        {
                            System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/circulars/"), model.FileName));
                        }

                        string fileName = model.Title.ToLowerInvariant().Replace(' ', '-') + "-" + DateTime.Now.ToString("MM-dd-yyyy") + "-" + (new Random()).Next(1000, 5000).ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/circulars/"), fileName));

                        obj.FileName = fileName;
                        model.FileName = fileName;
                    }

                }


                obj.UserId = (int)_currentUser.User.Id;



                if (_circularsService.Save(obj) > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<CircularsController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            CircularsModel model = new CircularsModel();
            try
            {
                model = _circularsService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<CircularsController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Delete(int? Id)
        {
            bool result = false;
            try
            {
                if (Id == null)
                {
                    return RedirectToAction<CircularsController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _circularsService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _circularsService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/circulars/"), data.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/circulars/"), data.FileName));
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        #region Helper

        [HttpGet]
        public JsonResult GetCircularsList(int sessionId, int pageNumber, int pageSize)
        {
            try
            {
                var session = _commonService.GetSessionList().Where(a => a.Id == sessionId).FirstOrDefault();
                int sessionYear = string.IsNullOrEmpty(session.Name) ? GetCurrentYear() : Convert.ToInt32(session.Name.Split('-')[0]);
                var list = _circularsService.GetList(session.Name, pageNumber, pageSize);
                int totalItems = _circularsService.GetListCount(sessionYear);
                var pager = new Pager(totalItems, pageNumber, pageSize);
                var viewMOdel = new CircularsViewModel()
                {
                    CircularsModels = list.ToModel(),
                    Pager = pager
                };
                return Json(viewMOdel, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CheckNameExist(string Name, string Id)
        {
            bool result = true;
            int id = Id == "undefined" ? 0 : int.Parse(Id);
            result = !_circularsService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region PTM
        /// <summary>
        /// initial load the PTM admin Page
        /// </summary>
        /// <returns></returns>
        public ActionResult PTMSchedule()
        {
            return View();
        }
        /// <summary>
        /// list of ptm 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetPtmList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _circularsService.GetListPtm(pageNumber, pageSize);
                int totalItems = list.Count > 0 ? list.FirstOrDefault().TotalRecords : 0;
                var pager = new Pager(totalItems, pageNumber, pageSize);
                var viewMOdel = new PtmViewModel()
                {
                    PtmModels = list.ToModel(),
                    Pager = pager
                };
                return Json(viewMOdel, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// open edit ptm page
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult CreateEditPtm(int? Id)
        {
            PtmModel model = new PtmModel();
            try
            {
                if(Id!=null)
                model = _circularsService.GetByIdPtm(Id ?? 0).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<CircularsController>(m => m.PTMSchedule())
                                        .WithError(ex.Message);
            }

            return View(model);
        }
        /// <summary>
        /// create edit ptm
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEditPtm(PtmModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var obj = model.ToEntity();
                string messare = model.Id > 0 ? "Updated Successfully!" : "Saved Successfully!";
                obj.UserId = (int)_currentUser.User.Id;
                if (_circularsService.SavePtm(obj) > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.PTMSchedule())
                                        .WithSuccess(messare);
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<CircularsController>(m => m.CreateEditPtm(model))
                                        .WithError(ex.Message);
            }
            return View(model);
        }
        /// <summary>
        /// detail ptm
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DetailsPtm(int? Id)
        {
            PtmModel model = new PtmModel();
            try
            {
                model = _circularsService.GetByIdPtm(Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<CircularsController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult DeletePtm(int Id)
        {
            bool result = false;
            try
            {
                result = _circularsService.DeletePtmById(Id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        private int GetCurrentYear()
        {
            return DateTime.Today.Month > 3 ? DateTime.Today.Year : DateTime.Today.Year - 1;
        }
    }
}