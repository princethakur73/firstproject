using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Alerts;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class AcademicsController : WebApplicationController
    {

        private IPageService _pageService;
        private ICurrentUser _currentUser;

        public AcademicsController(IPageService pageService, ICurrentUser currentUser)
        {
            _pageService = pageService;
            _currentUser = currentUser;
        }
        public ActionResult Result()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.Result).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.Result;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AcademicsController>(m => m.Result(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AcademicsController>(m => m.Result(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult Schedule()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.Schedule).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schedule(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.Schedule;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AcademicsController>(m => m.Schedule(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AcademicsController>(m => m.Schedule(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }
    }
}