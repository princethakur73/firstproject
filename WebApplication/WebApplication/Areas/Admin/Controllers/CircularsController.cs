using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public CircularsController(IPageService pageService, ICurrentUser currentUser, ICircularsService circularsService)
        {
            _pageService = pageService;
            _currentUser = currentUser;
            _circularsService = circularsService;
        }
        // GET: Admin/Circulars
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimeTable()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.TimeTable).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TimeTable(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.TimeTable;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<CircularsController>(m => m.TimeTable(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<CircularsController>(m => m.TimeTable(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
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

        public ActionResult PTMSchedule()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.PTMSchedule).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
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
        public JsonResult GetCircularsList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _circularsService.GetList(pageNumber, pageSize);
                int totalItems = _circularsService.GetListCount(pageNumber, pageSize);

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

    }
}