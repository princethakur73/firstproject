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
    public class ClassMasterController : WebApplicationController
    {
        private IClassMasterService _ClassService;
        private ICurrentUser _currentUser;
        private ICommonService _commonService;

        public ClassMasterController(IClassMasterService ClassService,
            ICurrentUser currentUser,
            ICommonService commonService)
        {
            _ClassService = ClassService;
            _currentUser = currentUser;
            _commonService = commonService;


        }

        // GET: Class
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View(new ClassModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassModel model)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();

                obj.UserId = (int)_currentUser.User.Id;

                if (_ClassService.Save(obj) > 0)
                {
                    return RedirectToAction<ClassMasterController>(m => m.Index())
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
            ClassModel model = new ClassModel();
            try
            {
                model = _ClassService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<ClassMasterController>(m => m.Index())
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var obj = model.ToEntity();

                obj.UserId = (int)_currentUser.User.Id;


                if (_ClassService.Save(obj) > 0)
                {
                    return RedirectToAction<ClassMasterController>(m => m.Index())
                                        .WithSuccess("Updated Successfully!");
                }
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<ClassMasterController>(m => m.Edit(model))
                                        .WithError(ex.Message);
            }

            return View(model);
        }

        public ActionResult Details(int? Id)
        {
            ClassModel model = new ClassModel();
            try
            {
                model = _ClassService.GetById(Id ?? 0, _currentUser.User.Id).ToModel();
            }
            catch (System.Exception ex)
            {
                return RedirectToAction<ClassMasterController>(m => m.Index())
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
                    return RedirectToAction<ClassMasterController>(m => m.Index())
                        .WithError("Unable to delete, record is already in use.");
                }
                result = _ClassService.DeleteById(Id ?? 0, _currentUser.User.Id);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        #region Helper

        [HttpGet]
        public JsonResult GetClassList(int pageNumber, int pageSize)
        {
            try
            {
                var list = _ClassService.GetList(pageNumber, pageSize);
                int totalItems = _ClassService.GetListCount(pageNumber, pageSize);

                var pager = new Pager(totalItems, pageNumber, pageSize);

                var viewMOdel = new ClassViewModel()
                {
                    ClassModels = list.ToModel(),
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
            result = !_ClassService.IsNameExist(Name, id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}