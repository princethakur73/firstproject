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
    public class TransferCertificateController : WebApplicationController
    {
        private ITransferCertificateService _transferCertificateService;
        private IClassMasterService _classMasterService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;
        public TransferCertificateController(ITransferCertificateService transferCertificateService,
            ICurrentUser currentUser,
            IClassMasterService classMasterService,
            ICommonService commonService)
        {
            _transferCertificateService = transferCertificateService;
            _classMasterService = classMasterService;
            _currentUser = currentUser;
            _commonService = commonService;

        }
        // GET: Downloads
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
            return View(new TransferCertificateModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransferCertificateModel model)
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

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/files/downloads/"), fileName));

                        obj.FileName = fileName;
                        obj.Extenstion = Path.GetExtension(file.FileName);
                        model.FileName = fileName;
                    }

                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_transferCertificateService.Save(obj) > 0)
                {
                    return RedirectToAction<TransferCertificateController>(m => m.Index())
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
            TransferCertificateModel model = new TransferCertificateModel();
            try
            {
                model = _transferCertificateService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<TransferCertificateController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(TransferCertificateModel model)
        //{
        //    try
        //    {

        //        HttpPostedFileBase file = Request.Files["file"];

        //        if (file.ContentLength == 0 && model.FileName == null)
        //        {
        //            ModelState.AddModelError("FileName", "Please give valid file.");
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return View(model);
        //        }

        //        var obj = model.ToEntity();
        //        if (file != null)
        //        {
        //            if (file.ContentLength > 0)
        //            {
        //                if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/downloads/"), model.FileName)))
        //                {
        //                    System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/downloads/"), model.FileName));
        //                }

        //                string fileName = model.Title.ToLowerInvariant().Replace(' ', '-') + "-" + model.Date.Date.ToString("MM-dd-yyyy") + "-" + (new Random()).Next(1000, 5000).ToString() + Path.GetExtension(file.FileName);

        //                file.SaveAs(string.Concat(Server.MapPath("~/Content/files/downloads/"), fileName));

        //                obj.FileName = fileName;
        //                model.FileName = fileName;
        //            }

        //        }


        //        obj.UserId = (int)_currentUser.User.Id;



        //        if (_transferCertificateService.Save(obj) > 0)
        //        {
        //            return RedirectToAction<DownloadsController>(m => m.Index())
        //                                .WithSuccess("Updated Successfully!");
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return RedirectToAction<DownloadsController>(m => m.Edit(model))
        //                                .WithError(ex.Message);
        //    }

        //    return View(model);
        //}

        public ActionResult Details(int? Id)
        {
            TransferCertificateModel model = new TransferCertificateModel();
            try
            {
                model = _transferCertificateService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<TransferCertificateController>(m => m.Index())
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
                    return RedirectToAction<DownloadsController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _transferCertificateService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _transferCertificateService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/files/downloads/"), data.FileName)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/files/downloads/"), data.FileName));
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
        public JsonResult GetTransferCertificateList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _transferCertificateService.GetList(pageNumber, pageSize);
                int totalItems = _transferCertificateService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new TransferCertificateViewModel()
                {
                    TransferCertificateModels = list.ToModel(),
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
            result = !_transferCertificateService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}