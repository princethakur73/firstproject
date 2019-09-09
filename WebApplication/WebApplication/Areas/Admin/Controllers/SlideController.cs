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
    public class SlideController : WebApplicationController
    {
        private ISlideService _SlideService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public SlideController(ISlideService SlideService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _SlideService = SlideService;
            _currentUser = currentUser;
            _commonService = commonService;


        }

        // GET: Slide
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
            return View(new SlideModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SlideModel model, string avatarCropped)
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
                else
                {
                    ModelState.AddModelError("Image", "Please give slide image.");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();
                obj.IsActive = true;
                obj.Title = " ";
                string filePath = ProcessImage(avatarCropped);

                obj.Image = filePath;
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string image = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/images/Slide/"), image));

                        obj.Image = image;
                        model.Image = image;
                    }
                }

                obj.UserId = (int)_currentUser.User.Id;

                if (_SlideService.Save(obj) > 0)
                {
                    return RedirectToAction<SlideController>(m => m.Index())
                                        .WithSuccess("Saved Successfully!");
                }

                return View(model).WithError("Error occurred while saving record.");
            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }

        }

        /// <summary>
        /// Process image and save in predefined path
        /// </summary>
        /// <param name="croppedImage"></param>
        /// <returns></returns>
        private string ProcessImage(string croppedImage)
        {
            string filePath = String.Empty;
            try
            {
                string base64 = croppedImage;
                byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
                filePath = "/Images/Photo/Emp-" + Guid.NewGuid() + ".png";

                using (FileStream stream = new FileStream(Server.MapPath(filePath), FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                string st = ex.Message;
            }
            return filePath;
        }

        public ActionResult Edit(int? Id)
        {
            SlideModel model = new SlideModel();
            try
            {
                model = _SlideService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<SlideController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SlideModel model)
        {
            try
            {
                string oldFile = model.Image;
                bool newFile = false;
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

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/images/Slide/"), image));

                        obj.Image = image;
                        model.Image = image;
                        newFile = true;
                    }

                }
                obj.UserId = (int)_currentUser.User.Id;


                if (_SlideService.Save(obj) > 0)
                {
                    if (newFile && System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/images/Slide/"), oldFile)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/images/Slide/"), oldFile));
                    }

                    return RedirectToAction<SlideController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<SlideController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            SlideModel model = new SlideModel();
            try
            {
                model = _SlideService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<SlideController>(m => m.Index())
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
                    return RedirectToAction<SlideController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _SlideService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _SlideService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/images/Slide/"), data.Image)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/images/Slide/"), data.Image));
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
        public JsonResult GetSlideList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _SlideService.GetList(pageNumber, pageSize);
                int totalItems = _SlideService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new SlideViewModel()
                {
                    SlideModels = list.ToModel(),
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
            result = !_SlideService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}