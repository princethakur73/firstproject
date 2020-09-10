using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Area.Admin.Models;
using WebApplication.Core;
using WebApplication.Core.Common;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Alerts;
using WebApplication.Service;
using WebApplication.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class GalleryController : WebApplicationController
    {
        private IGalleryService _GalleryService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public GalleryController(IGalleryService GalleryService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _GalleryService = GalleryService;
            _currentUser = currentUser;
            _commonService = commonService;


        }

        // GET: Gallery
        public ActionResult Index()
        {
            GalleryModel galleryModel = new GalleryModel();
            galleryModel.SessionId = _GalleryService.GetCurrentSession();
            return View(galleryModel);
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new GalleryModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalleryModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    if (model.Name.ToLower() == "others")
                    {
                        ModelState.AddModelError("Name", "'Others' keyword is already in use.");
                    }
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();
                obj.UserId = (int)_currentUser.User.Id;

                if (_GalleryService.Save(obj) > 0)
                {
                    return RedirectToAction<GalleryController>(m => m.Index())
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
            GalleryModel model = new GalleryModel();
            try
            {
                model = _GalleryService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<GalleryController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GalleryModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    if (model.Name.ToLower() == "others")
                    {
                        ModelState.AddModelError("Name", "'Others' keyword is already in use.");
                    }
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();

                if (_GalleryService.Save(obj) > 0)
                {
                    return RedirectToAction<GalleryController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<GalleryController>(m => m.Create(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            GalleryModel model = new GalleryModel();
            try
            {
                model = _GalleryService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<GalleryController>(m => m.Index())
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
                    return RedirectToAction<GalleryController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                result = _GalleryService.DeleteById(Id ?? 0, _currentUser.User.Id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Photo(int? Id)
        {

            return View(new FileModel() { EntityId = Id ?? 0, Type = "Photo" });
        }

        [HttpPost]
        public ActionResult Photo()
        {
            List<ViewDataUploadFilesResult> resultList = new List<ViewDataUploadFilesResult>();
            try
            {
                resultList = _GalleryService.SavePhotos(HttpContext, Request.Form["MediaUploadType"].ToString(), (int)_currentUser.User.Id);
                JsonFiles files = new JsonFiles(resultList);

                bool isEmpty = !resultList.Any();
                if (isEmpty)
                {
                    return JsonError("Error ");
                }
                else
                {
                    return JsonSuccess(files);
                }
            }
            catch (System.Exception ex)
            {
                resultList.ForEach(m => m.error = ex.Message);
                JsonFiles files = new JsonFiles(resultList);
                return JsonSuccess(files);
            }

        }

        public ActionResult Video(int? Id)
        {
            return View(new FileModel() { EntityId = Id ?? 0, Type = "Video" });
        }

        [HttpPost]
        public ActionResult Video()
        {
            var resultList = _GalleryService.SaveVideos(HttpContext, Request.Form["MediaUploadType"].ToString(), (int)_currentUser.User.Id);
            JsonFiles files = new JsonFiles(resultList);

            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return JsonError("Error ");
            }
            else
            {
                return JsonSuccess(files);
            }
        }

        public JsonResult GetPhotosFileList(int? id, string mediaType)
        {
            var list = _GalleryService.GetGalleryPhotosByGalleryId(id);
            if (list != null)
                list = list.Where(m => m.MediaType == mediaType).ToList();

            JsonFiles files = new JsonFiles(list);
            return Json(files, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVideosFileList(int? id)
        {
            var list = _GalleryService.GetGalleryVideosByGalleryId(id);
            JsonFiles files = new JsonFiles(list);
            return Json(files, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult DeletePhotoFile(string file)
        {
            _GalleryService.DeleteGalleryPhotoById(int.Parse(file));
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeletePhotoByPictureId(int id)
        {
            return Json(_GalleryService.DeleteGalleryPhotoById(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteVideoFile(string file)
        {
            _GalleryService.DeleteGalleryVideoByName(file);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        #region Helper

        [HttpGet]
        public JsonResult GetGalleryList(int sessionId, int pageNumber, int pageSize)
        {
            try
            {
                var list = _GalleryService.GetList(sessionId,pageNumber, pageSize);
                int totalItems = _GalleryService.GetListCount(sessionId,pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new GalleryViewModel()
                {
                    GalleryModels = list.ToModel(),
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
            result = !_GalleryService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}