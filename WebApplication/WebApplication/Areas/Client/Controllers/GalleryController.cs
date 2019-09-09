using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication.Service;
using WebApplication.ViewModels;

namespace WebApplication.Areas.Client.Controllers
{
    public class GalleryController : Controller
    {
        private IGalleryService _galleryService;
        private readonly ICommonService _commonService;

        public GalleryController(IGalleryService galleryService,
            ICommonService commonService)
        {
            _galleryService = galleryService;
            _commonService = commonService;
        }

        // GET: Client/Gallery
        [Route("videos")]
        public ActionResult Videos()
        {
            return View("~/Areas/Client/Views/Gallery/Videos.cshtml");
        }

        // GET: Client/Gallery
        [Route("session-photo-gallery/{session}")]
        public async Task<ActionResult> SessionPhotoGallery(string session)
        {

            if (_commonService.GetSessionByName(session) == null)
                return Redirect("/");

            var data = await _galleryService.GetGalleryBySessionNameAsync(session);

            return View("~/Areas/Client/Views/Gallery/SessionPhotoGallery.cshtml", data);
        }

        // GET: Client/Gallery
        [Route("school-virtual-tour")]
        public ActionResult SchoolVirtualTour(string session)
        {
            return View("~/Areas/Client/Views/Gallery/SchoolVirtualTour.cshtml");
        }

        [Route("photos/{sessionName}/{galleryId}")]
        public ActionResult Photos(string sessionName, int galleryId)
        {
            var gallery = _galleryService.GetById(galleryId, 0);
            if (gallery != null)
            {
                if (gallery.SessionName != sessionName)
                {
                    return Redirect("/");
                }
            }
            else
                return Redirect("/");

            var data = _galleryService.GetGalleryPhotosByGalleryId(galleryId);

            var model = new PhotoViewModel()
            {
                Gallery = gallery,
                Photos = data
            };

            return View("~/Areas/Client/Views/Gallery/Photos.cshtml", model);

        }

    }
}