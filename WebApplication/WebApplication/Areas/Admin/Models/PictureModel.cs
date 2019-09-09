
namespace WebApplication.Area.Admin.Models
{
    public class PictureModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public string MimeType { get; set; }

        public bool IsDefault { get; set; }

        public int UserId { get; set; }
    }
}