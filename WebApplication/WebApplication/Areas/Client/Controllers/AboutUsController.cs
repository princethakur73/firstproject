using System.Web.Mvc;
using WebApplication.Core.Common;
using WebApplication.Service;

namespace WebApplication.Areas.Client.Controllers
{
    public class AboutUsController : Controller
    {
        private IPageService _pageService;
        private IStaffDetailService _StaffDetailService;
        private IMemberService _MemberService;
        public AboutUsController(IStaffDetailService staffDetailService,
            IMemberService memberService,
            IPageService pageService)
        {
            _pageService = pageService;
            _StaffDetailService = staffDetailService;
            _MemberService = memberService;
        }
        // GET: Client/AboutUs
        [Route("origins-history")]
        public ActionResult OriginsHistory()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.OriginsHistory).ToModel();
            return View("~//Areas//Client//Views//AboutUs//OriginsHistory.cshtml", model);
        }

        [Route("messages")]
        public ActionResult Messages()
        {
            return View("~/Areas/Client/Views/AboutUs/Messages.cshtml");
        }

        [Route("president-message")]
        public ActionResult PresidentMassage()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.PresidentMessage).ToModel();
            return View("~/Areas/Client/Views/AboutUs/PresidentMassage.cshtml", model);
        }

        [Route("director-message")]
        public ActionResult DirectorMassage()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.DirectorMessage).ToModel();
            return View("~/Areas/Client/Views/AboutUs/DirectorMassage.cshtml", model);
        }

        [Route("principal-message")]
        public ActionResult PrincipalMassage()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.PrincipalMessage).ToModel();

            return View("~/Areas/Client/Views/AboutUs/PrincipalMassage.cshtml", model);
        }

        [Route("vision-mission")]
        public ActionResult VisionMission()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.VisionMission).ToModel();
            return View("~/Areas/Client/Views/AboutUs/VisionMission.cshtml", model);
        }

        [Route("mandatory-disclosure")]
        public ActionResult MandatoryDisclosure()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.MandatoryDisclosure).ToModel();
            return View("~/Areas/Client/Views/AboutUs/MandatoryDisclosure.cshtml", model);
        }

        [Route("course-offered")]
        public ActionResult CourseOffered()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.CourseOffered).ToModel();
            return View("~/Areas/Client/Views/AboutUs/CourseOffered.cshtml", model);
        }

        [Route("affiliation-cbse")]
        public ActionResult AffiliationCBSE()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.AffiliationtoCBSE).ToModel();
            return View("~/Areas/Client/Views/AboutUs/AffiliationCBSE.cshtml", model);
        }

        [Route("management-members")]
        public ActionResult ManagementMembers()
        {
            var members = _MemberService.GetList(currentUserId: 0).ToModel();
            return View("~/Areas/Client/Views/AboutUs/ManagementMembers.cshtml", members);
        }

        [Route("faculty-details")]
        public ActionResult FacultyDetails()
        {
            var staffList = _StaffDetailService.GetList(currentUserId: 0).ToModel();
            return View("~/Areas/Client/Views/AboutUs/FacultyDetails.cshtml", staffList);
        }

        [Route("our-infrastructure")]
        public ActionResult OurInfrastructure()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.OurInfrastructure).ToModel();
            return View("~/Areas/Client/Views/AboutUs/OurInfrastructure.cshtml", model);
        }

        [Route("our-facilities")]
        public ActionResult OurFacilities()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.OurFacilities).ToModel();
            return View("~/Areas/Client/Views/AboutUs/OurFacilities.cshtml", model);
        }

        [Route("our-rules")]
        public ActionResult OurRules()
        {
            var model = _pageService.GetPageByMenuCode(MenuCode.OurRules).ToModel();
            return View("~/Areas/Client/Views/AboutUs/OurRules.cshtml", model);
        }

    }
}