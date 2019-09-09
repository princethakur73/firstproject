
namespace WebApplication.Area.Admin.Models
{
    public class GalleryPictureMappingModel
    {
        public int GalleryId { get; set; }
        public GalleryModel GalleryModel { get; set; }

        public int PictureId { get; set; }
        public PictureModel PictureModel { get; set; }
    }
}