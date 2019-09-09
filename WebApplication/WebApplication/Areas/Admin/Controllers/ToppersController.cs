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
    public class ToppersController : WebApplicationController
    {
        private IToppersService _ToppersService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public ToppersController(IToppersService ToppersService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _ToppersService = ToppersService;
            _currentUser = currentUser;
            _commonService = commonService;


        }

        // GET: Toppers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new ToppersModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToppersModel model)
        {
            try
            {

                HttpPostedFileBase file = Request.Files["ImageData"];
                if (file != null)
                {
                    if (file.ContentLength > 500000)
                    {
                        throw new Exception("The photo size cannot be greater than 500 KB.");
                    }
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
                        string image = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/images/Toppers/"), image));

                        obj.Image = image;
                        model.Image = image;
                    }
                    else
                    {
                        obj.Image = model.RemoveImage == 1 ? null : model.Image;
                    }
                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_ToppersService.Save(obj) > 0)
                {
                    return RedirectToAction<ToppersController>(m => m.Index())
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
            ToppersModel model = new ToppersModel();
            try
            {
                model = _ToppersService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<ToppersController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToppersModel model)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["ImageData"];
                if (file != null)
                {
                    if (file.ContentLength > 500000)
                    {
                        throw new Exception("The photo size cannot be greater than 500 KB.");
                    }
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
                        string image = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/images/Toppers/"), image));

                        obj.Image = image;
                        model.Image = image;
                    }
                    else
                    {
                        obj.Image = model.RemoveImage == 1 ? null : model.Image;
                    }
                }
                obj.UserId = (int)_currentUser.User.Id;


                if (_ToppersService.Save(obj) > 0)
                {
                    return RedirectToAction<ToppersController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<ToppersController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            ToppersModel model = new ToppersModel();
            try
            {
                model = _ToppersService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<ToppersController>(m => m.Index())
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
                    return RedirectToAction<ToppersController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _ToppersService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _ToppersService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/images/Toppers/"), data.Image)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/images/Toppers/"), data.Image));
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
        public JsonResult GetToppersList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _ToppersService.GetList(pageNumber, pageSize);
                int totalItems = _ToppersService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new ToppersViewModel()
                {
                    ToppersModels = list.ToModel(),
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
            result = !_ToppersService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}