using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.EnumHelper;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Alerts;
using WebApplication.Models;
using WebApplication.Service;
using WebApplication.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class TimetableController : WebApplicationController
    {
        private IFileService _fileService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public TimetableController(IFileService fileService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _fileService = fileService;
            _currentUser = currentUser;
            _commonService = commonService;
        }

        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            FileTypeModel model = new FileTypeModel();
            model.Type = (int)FiletypeEnum.Timetable;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FileTypeModel model)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["file"];

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName).ToLowerInvariant().Replace(' ', '-') + "-" + model.Session.Date.ToString("MM-dd-yyyy") + "-" + (new Random()).Next(1000, 5000).ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/timetable/"), fileName));

                        obj.FileName = fileName;
                        model.FileName = fileName;
                    }

                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_fileService.Save(obj) > 0)
                {
                    return RedirectToAction<TimetableController>(m => m.Index())
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
            FileTypeModel model = new FileTypeModel();
            try
            {
                model = _fileService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<TimetableController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FileTypeModel model)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["file"];

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if (!Directory.Exists(string.Concat(Server.MapPath("~/Content/files/timetable/"))))
                {
                    Directory.CreateDirectory(string.Concat(Server.MapPath("~/Content/files/timetable/")));
                }
                var obj = model.ToEntity();
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/timetable/"), model.FileName)))
                        {
                            System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/timetable/"), model.FileName));
                        }

                        string fileName = Path.GetFileNameWithoutExtension(file.FileName).ToLowerInvariant().Replace(' ', '-') + "-" + model.Session.Date.ToString("MM-dd-yyyy") + "-" + (new Random()).Next(1000, 5000).ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/timetable/"), fileName));

                        obj.FileName = fileName;
                        model.FileName = fileName;
                    }

                }
                if (model.IsRemoveFile)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/timetable/"), model.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/timetable/"), model.FileName));
                    }

                    model.FileName = null;
                    obj.FileName = null;
                }


                obj.UserId = (int)_currentUser.User.Id;



                if (_fileService.Save(obj) > 0)
                {
                    return RedirectToAction<TimetableController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<TimetableController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            FileTypeModel model = new FileTypeModel();
            try
            {
                model = _fileService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<TimetableController>(m => m.Index())
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
                    return RedirectToAction<TimetableController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _fileService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _fileService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/timetable/"), data.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/timetable/"), data.FileName));
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
        public JsonResult GetTimetableList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _fileService.GetList(pageNumber, pageSize, (int)FiletypeEnum.Timetable);
                int totalItems = _fileService.GetListCount(pageNumber, pageSize, (int)FiletypeEnum.Timetable);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new FileViewModel()
                {
                    FileModels = list.ToModel(),
                    Pager = pager
                };
                return Json(viewMOdel, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }

        }

        #endregion
    }
}