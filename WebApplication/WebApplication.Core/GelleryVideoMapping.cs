
namespace WebApplication.Core
{
    public class GelleryVideoMapping
    {
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }

        public int VideoId { get; set; }
        public Video Video { get; set; }
    }
}