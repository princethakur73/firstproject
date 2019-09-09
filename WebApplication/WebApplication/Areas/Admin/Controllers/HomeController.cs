using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.Service;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ICurrentUser currentUser;
        private INewsService newsService;
        public HomeController(ICurrentUser _currentUser,
                            INewsService _newsService)
        {
            currentUser = _currentUser;
            newsService = _newsService;
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
    }
}