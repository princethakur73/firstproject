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
    public class MemberController : WebApplicationController
    {
        private IMemberService _MemberService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public MemberController(IMemberService MemberService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _MemberService = MemberService;
            _currentUser = currentUser;
            _commonService = commonService;


        }

        // GET: Member
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
            return View(new MemberModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberModel model)
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

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/images/Member/"), image));

                        obj.Image = image;
                        model.Image = image;
                    }
                    else
                    {
                        obj.Image = model.RemoveImage == 1 ? null : model.Image;
                    }
                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_MemberService.Save(obj) > 0)
                {
                    return RedirectToAction<MemberController>(m => m.Index())
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
            MemberModel model = new MemberModel();
            try
            {
                model = _MemberService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<MemberController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberModel model)
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

                        file.SaveAs(string.Concat(Server.MapPath("~/Content/images/Member/"), image));

                        obj.Image = image;
                        model.Image = image;
                    }
                    else
                    {
                        obj.Image = model.RemoveImage == 1 ? null : model.Image;
                    }
                }
                obj.UserId = (int)_currentUser.User.Id;


                if (_MemberService.Save(obj) > 0)
                {
                    return RedirectToAction<MemberController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<MemberController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            MemberModel model = new MemberModel();
            try
            {
                model = _MemberService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<MemberController>(m => m.Index())
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
                    return RedirectToAction<MemberController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _MemberService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _MemberService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/images/Member/"), data.Image)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/images/Member/"), data.Image));
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
        public JsonResult GetMemberList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _MemberService.GetList(pageNumber, pageSize);
                int totalItems = _MemberService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new MemberViewModel()
                {
                    MemberModels = list.ToModel(),
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
            result = !_MemberService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}