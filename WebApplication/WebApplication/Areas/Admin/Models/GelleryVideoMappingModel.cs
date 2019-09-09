
namespace WebApplication.Area.Admin.Models
{
    public class GelleryVideoMappingModel
    {
        public int GalleryId { get; set; }
        public GalleryModel GalleryModel { get; set; }

        public int VideoId { get; set; }
        public VideoModel VideoModel { get; set; }
    }
}