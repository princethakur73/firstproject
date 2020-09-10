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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdmissionRule()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.AdmissionRules).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdmissionRule(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.AdmissionRules;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AdmissionController>(m => m.AdmissionRule(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AdmissionController>(m => m.AdmissionRule(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult FeeStructure()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.FeeStructure).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeeStructure(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.FeeStructure;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AdmissionController>(m => m.FeeStructure(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AdmissionController>(m => m.FeeStructure(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult GetAdmissionList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _admissionService.GetList(pageNumber, pageSize);
                int totalItems = _admissionService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new AdmissionViewModel()
                {
                    StudentAdmissionModels = list.ToModel(),
                    Pager = pager
                };
                return Json(viewMOdel, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }

        }


        public ActionResult Details(int? Id)
        {
            StudentAdmissionModel model = new StudentAdmissionModel();
            try
            {
                model = _admissionService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<AdmissionController>(m => m.Index())
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
                    return RedirectToAction<AdmissionController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                var data = _admissionService.GetById(Id ?? 0, _currentUser.User.Id);
                result = _admissionService.DeleteById(Id ?? 0, _currentUser.User.Id);
                if (result)
                {
                    if (System.IO.File.Exists(string.Concat(Server.MapPath("~/Content/images/StudentAdmission/"), data.Image)))
                    {
                        System.IO.File.Delete(string.Concat(Server.MapPath("~/Content/images/StudentAdmission/"), data.Image));
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
    }
}