
namespace WebApplication.Core
{
    public class GalleryPicture : Base
    {
        public int GalleryId { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public bool IsDefault { get; set; }
    }
}