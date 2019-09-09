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
    public class NewsController : WebApplicationController
    {
        private INewsService _NewsService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public NewsController(INewsService NewsService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _NewsService = NewsService;
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
            return View(new NewsModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsModel model)
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
                        string fileName = model.Title.ToLowerInvariant().Replace(' ', '-') + "-" + model.Date.Date.ToString("MM-dd-yyyy") + "-" + (new Random()).Next(1000, 5000).ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/News/"), fileName));

                        obj.FileName = fileName;
                        model.FileName = fileName;
                    }

                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_NewsService.Save(obj) > 0)
                {
                    return RedirectToAction<NewsController>(m => m.Index())
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
            NewsModel model = new NewsModel();
            try
            {
                model = _NewsService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<NewsController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsModel model)
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
                        if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/News/"), model.FileName)))
                        {
                            System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/News/"), model.FileName));
                        }

                        string fileName = model.Title.ToLowerInvariant().Replace(' ', '-') + "-" + model.Date.Date.ToString("MM-dd-yyyy") + "-" + (new Random()).Next(1000, 5000).ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/News/"), fileName));

                        obj.FileName = fileName;
                        model.FileName = fileName;
                    }

                }
                if (model.IsRemoveFile)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/News/"), model.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/News/"), model.FileName));
                    }

                    model.FileName = null;
                    obj.FileName = null;
                }


                obj.UserId = (int)_currentUser.User.Id;



                if (_NewsService.Save(obj) > 0)
                {
                    return RedirectToAction<NewsController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<NewsController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            NewsModel model = new NewsModel();
            try
            {
                model = _NewsService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<NewsController>(m => m.Index())
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
                    return RedirectToAction<NewsController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _NewsService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _NewsService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/News/"), data.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/News/"), data.FileName));
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
        public JsonResult GetNewsList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _NewsService.GetList(pageNumber, pageSize);
                int totalItems = _NewsService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new NewsViewModel()
                {
                    NewsModels = list.ToModel(),
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
            result = !_NewsService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}