using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Area.Admin.Models;
using WebApplication.Core;
using WebApplication.Infrastructure;
using WebApplication.Service;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : WebApplicationController
    {
        private ICurrentUser _currentUser;
        private INewsService _newsService;
        public HomeController(ICurrentUser currentUser,
                            INewsService newsService)
        {
            _currentUser = currentUser;
            _newsService = newsService;
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult DashboardV2()
        {

            //var viewModel = new Dashboard()
            //{
            //    DashboardCardCount = new DashboardCardCount()
            //};

            return View();
        }



        public ActionResult Index()
        {

            return View();
        }


        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult PressMedia()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View(new FileModel() { Type = "Upload" });
        }

        [HttpPost]
        public ActionResult Upload(string path)
        {
            List<ViewDataUploadFilesResult> resultList = new List<ViewDataUploadFilesResult>();
            try
            {
                resultList = _newsService.Upload(HttpContext, path);
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
    }
}