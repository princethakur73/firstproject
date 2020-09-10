using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Alerts;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class AdmissionController : WebApplicationController
    {
        private IPageService _pageService;
        private ICurrentUser _currentUser;
        private IAdmissionService _admissionService;
        public AdmissionController(IPageService pageService, ICurrentUser currentUser, IAdmissionService admissionService)
        {
            _pageService = pageService;
            _currentUser = currentUser;
            _admissionService = admissionService;
        }

        [Route("admission-rule")]
        public ActionResult AdmissionRule()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.AdmissionRules).ToModel();

            return View("~/Areas/Client/Views/Admission/AdmissionRule.cshtml", model);
        }

        [Route("fee-structure")]
        public ActionResult FeeStructure()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.FeeStructure).ToModel();

            return View("~/Areas/Client/Views/Admission/FeeStructure.cshtml", model);
        }

        [Route("admission-form")]
        [HttpGet]
        public ActionResult AdmissionForm()
        {
            //var model = _pageService.GetPageByMenuCode(MenuCode.FeeStructure).ToModel();
            StudentAdmissionModel model = new StudentAdmissionModel();

            return View("~/Areas/Client/Views/Admission/AdmissionForm.cshtml", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admission-form")]
        public ActionResult AdmissionForm(StudentAdmissionModel model)
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
                    return View("~/Areas/Client/Views/Admission/AdmissionForm.cshtml", model);
                }

                var obj = model.ToEntity();
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        string image = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string root = string.Concat(Server.MapPath("~/Content/images/StudentAdmission/"), image);
                        if (!Directory.Exists(Server.MapPath("~/Content/images/StudentAdmission/")))
                        {
                            Directory.CreateDirectory(root);
                        }

                        file.SaveAs(root);

                        obj.Image = image;
                        model.Image = image;
                    }
                    else
                    {
                        obj.Image = model.RemoveImage == 1 ? null : model.Image;
                    }
                }


                obj.UserId = (int)_currentUser.User.Id;

                if (_admissionService.Save(obj) > 0)
                {
                    return RedirectToAction<AdmissionController>(m => m.AdmissionForm())
                                        .WithSuccess("Saved Successfully!");
                }

                return View(model).WithError("Error occurred while saving record.");
            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }


    }
}