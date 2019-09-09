
namespace WebApplication.Core
{
    public class GalleryPictureMapping
    {
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }

        public int PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}