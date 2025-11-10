using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication.Areas.Client.Models;
using WebApplication.Core.Helper;
using WebApplication.Models;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class HomeController : Controller
    {

        private INewsService newsService;

        public IToppersService toppersService { get; }
        private ICircularsService _circularsService;

        public HomeController(INewsService _newsService,
            IToppersService _toppersService, ICircularsService circularsService)
        {
            newsService = _newsService;
            toppersService = _toppersService;
            _circularsService = circularsService;
        }
        // GET: Client/Home
        public ActionResult Index()
        {
            var data = newsService.GetList();
            if (data != null)
                data = data.Where(m => m.IsActive == true).OrderBy(m => m.SortId).ToList();

            var toppersModels = toppersService.GetList(currentUserId: 0).ToModel();
            var circularsModel = _circularsService.GetList().ToModel();

            var homeModels = new HomeModels()
            {
                NewsModels = data.ToModel(),
                ToppersModels = toppersModels,
                CircularsModel = circularsModel,
            };

            return View("~/Areas/Client/Views/Home/Index.cshtml", homeModels);
        }
        public ActionResult FirstVisit()
        {
            return PartialView("~/Areas/Client/Views/Home/_HomePage.cshtml");
        }

        [HttpPost]
        public ActionResult FirstVisit(FirstVistModel model)
        {
            var result = EmailHelper.SendEmail(model.Contact, model.Name, model.Description);
            return Json(result);
        }

        [Route("contact-us")]
        public ActionResult ContactUs()
        {
            return View("~/Areas/Client/Views/Home/ContactUs.cshtml");
        }

        [Route("contact-us")]
        [HttpPost]
        public ActionResult ContactUs(ContactUsModel contact)
        {
            // Verify reCAPTCHA
            var response = Request["g-recaptcha-response"];
            string secret = AppSetting.CaptchaSecret; // "6LekLMsrAAAAAK_c8Wf67splJItnmjyMEmvbqqxY";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            if (!status)
            {
                return Json(new { success = false, message = "Please verify that you are not a robot" });
            }

            #region Send Confirmation to Candidate

            string body = "<div>Hello <br>Please check the following detail of the user who visit over the site.<br>" +
                    "Name: " + contact.Name + "<br>" +
                    "Subject: " + contact.Subject + "<br>" +
                    "Conatct: " + contact.Email + "<br>" +
                    "Message: " + contact.Message + "</div>";

            MailDefinition md = new MailDefinition
            {
                From = AppSetting.From,
                IsBodyHtml = true,
                Subject = string.Format("{0}", contact.Subject),
                Priority = MailPriority.High
            };

            MailMessage msg = md.CreateMailMessage(AppSetting.SchoolEmail, null, body, new System.Web.UI.Control());
            #endregion

            var reponse = EmailHelper.Send(msg);
            return Json(reponse);
        }

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