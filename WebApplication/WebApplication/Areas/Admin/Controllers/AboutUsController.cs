using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Alerts;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class AboutUsController : WebApplicationController
    {
        private IPageService _pageService;
        private ICurrentUser _currentUser;

        public AboutUsController(IPageService pageService, ICurrentUser currentUser)
        {
            _pageService = pageService;
            _currentUser = currentUser;
        }
        public ActionResult OriginsHistory()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.OriginsHistory).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OriginsHistory(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.OriginsHistory;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.OriginsHistory(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.OriginsHistory(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult Messages()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.DirectorMessage).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        public ActionResult PresidentMessage()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.PresidentMessage).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PresidentMessage(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.PresidentMessage;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.PresidentMessage(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.PresidentMessage(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult DirectorMessage()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.DirectorMessage).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DirectorMessage(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.DirectorMessage;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.DirectorMessage(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.DirectorMessage(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }


        public ActionResult PrincipalMessage()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.PrincipalMessage).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrincipalMessage(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.PrincipalMessage;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.PrincipalMessage(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.PrincipalMessage(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult ChairmanMessage()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.ChairPersonMessage).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChairmanMessage(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.ChairPersonMessage;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result = _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.ChairmanMessage(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.ChairmanMessage(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult VisionMission()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.VisionMission).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VisionMission(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.VisionMission;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.VisionMission(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.VisionMission(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult MandatoryDisclosure()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.MandatoryDisclosure).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MandatoryDisclosure(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.MandatoryDisclosure;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.MandatoryDisclosure(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.MandatoryDisclosure(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult CourseOffered()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.CourseOffered).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseOffered(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.CourseOffered;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.CourseOffered(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.CourseOffered(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult AffiliationCBSE()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.AffiliationtoCBSE).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AffiliationCBSE(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.AffiliationtoCBSE;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.AffiliationCBSE(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.AffiliationCBSE(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult ManagementMembers()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.ManagementMembers).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManagementMembers(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.ManagementMembers;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.ManagementMembers(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.ManagementMembers(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult FacultyDetails()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.FacultyDetails).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FacultyDetails(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.FacultyDetails;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.FacultyDetails(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.FacultyDetails(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult OurInfrastructure()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.OurInfrastructure).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OurInfrastructure(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.OurInfrastructure;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.OurInfrastructure(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.OurInfrastructure(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult OurFacilities()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.OurFacilities).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OurFacilities(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.OurFacilities;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.OurFacilities(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.OurFacilities(model))
                                       .WithError("Failed!");
                }

            }
            catch (System.Exception ex)
            {

                return View(model).WithError(ex.Message);
            }
        }

        public ActionResult OurRules()
        {
            PageModel pageModel = new PageModel();
            try
            {
                pageModel = _pageService.GetPageByMenuCode(MenuCode.OurRules).ToModel();
                return View(pageModel);
            }
            catch (System.Exception ex)
            {

                return View(pageModel).WithError(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OurRules(PageModel model)
        {
            try
            {
                var obj = model.ToEntity();
                obj.MenuCode = MenuCode.OurRules;
                obj.IsPublish = true;
                obj.UserId = (int)_currentUser.User.Id;
                var result= _pageService.Save(obj);
                if (result > 0)
                {
                    return RedirectToAction<AboutUsController>(m => m.OurRules(model))
                                        .WithSuccess("Saved Successfully!");
                }
                else
                {
                    return RedirectToAction<AboutUsController>(m => m.OurRules(model))
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