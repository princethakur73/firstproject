using System;
using System.IO;
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
    public class DatesheetController : WebApplicationController
    {
        private IDatesheetService _DatesheetService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public DatesheetController(IDatesheetService DatesheetService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _DatesheetService = DatesheetService;
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
            return View(new DatesheetModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DatesheetModel model)
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

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), fileName));

                        obj.FileName = fileName;
                        model.FileName = fileName;
                    }

                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_DatesheetService.Save(obj) > 0)
                {
                    return RedirectToAction<DatesheetController>(m => m.Index())
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
            DatesheetModel model = new DatesheetModel();
            try
            {
                model = _DatesheetService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<DatesheetController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DatesheetModel model)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["file"];

                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if (!Directory.Exists(string.Concat(Server.MapPath("~/Content/files/Datesheet/"))))
                {
                    Directory.CreateDirectory(string.Concat(Server.MapPath("~/Content/files/Datesheet/")));
                }
                var obj = model.ToEntity();
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), model.FileName)))
                        {
                            System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), model.FileName));
                        }

                        string fileName = Path.GetFileNameWithoutExtension(file.FileName).ToLowerInvariant().Replace(' ', '-') + "-" + model.Session.Date.ToString("MM-dd-yyyy") + "-" + (new Random()).Next(1000, 5000).ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), fileName));

                        obj.FileName = fileName;
                        model.FileName = fileName;
                    }

                }
                if (model.IsRemoveFile)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), model.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), model.FileName));
                    }

                    model.FileName = null;
                    obj.FileName = null;
                }


                obj.UserId = (int)_currentUser.User.Id;



                if (_DatesheetService.Save(obj) > 0)
                {
                    return RedirectToAction<DatesheetController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<DatesheetController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            DatesheetModel model = new DatesheetModel();
            try
            {
                model = _DatesheetService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<DatesheetController>(m => m.Index())
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
                    return RedirectToAction<DatesheetController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _DatesheetService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _DatesheetService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), data.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/Datesheet/"), data.FileName));
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
        public JsonResult GetDatesheetList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _DatesheetService.GetList(pageNumber, pageSize);
                int totalItems = _DatesheetService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new DatesheetViewModel()
                {
                    DatesheetModels = list.ToModel(),
                    Pager = pager
                };
                return Json(viewMOdel, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }

        }

        //public ActionResult CheckNameExist(string Name, string Id)
        //{
        //    bool result = true;
        //    int id = Id == "undefined" ? 0 : int.Parse(Id);
        //    result = !_DatesheetService.IsNameExist(Name, id);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        #endregion
    }
}