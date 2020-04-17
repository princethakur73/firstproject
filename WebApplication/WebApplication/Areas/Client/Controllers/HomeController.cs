using System.Linq;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class HomeController : Controller
    {

        private INewsService newsService;

        public IToppersService toppersService { get; }

        public HomeController(INewsService _newsService,
            IToppersService _toppersService)
        {
            newsService = _newsService;
            toppersService = _toppersService;
        }
        // GET: Client/Home
        public ActionResult Index()
        {
            var data = newsService.GetList();
            if (data != null)
                data = data.Where(m => m.IsActive == true).OrderBy(m => m.SortId).ToList();

            var toppersModels = toppersService.GetList(currentUserId: 0).ToModel();

            var homeModels = new HomeModels()
            {
                NewsModels = data.ToModel(),
                ToppersModels = toppersModels
            };

            return View("~/Areas/Client/Views/Home/Index.cshtml", homeModels);
        }

        [Route("contact-us")]
        public ActionResult ContactUs()
        {
            return View("~/Areas/Client/Views/Home/ContactUs.cshtml");
        }

        //[Route("contact-us")]
        //public ActionResult ContactUs(ContactUsModel contact)
        //{
        //    return View("~/Areas/Client/Views/Home/ContactUs.cshtml");
        //}

        [Route("press-media")]
        public ActionResult PressMedia()
        {
            return View("~/Areas/Client/Views/Home/PressMedia.cshtml");
        }

        [Route("latest-news")]
        public ActionResult News()
        {
            var data = newsService.GetList();
            if (data != null)
            {
                data = data.Where(m => m.IsActive == true).OrderBy(m => m.SortId).ToList();
                data.ForEach(m => m.Key = m.Id.ToEncrypt());
            }


            return View("~/Areas/Client/Views/Home/News.cshtml", data.ToModel());
        }

        public ActionResult NewsDetails(string token)
        {
            int id = 0;
            NewsModel news = new NewsModel();
            if (int.TryParse(token.ToDecrypt(), out id))
            {
                news = newsService.GetById(id, 0).ToModel();
                return View(news);
            }
            {
                return RedirectToAction("News");
            }

        }

    }
}