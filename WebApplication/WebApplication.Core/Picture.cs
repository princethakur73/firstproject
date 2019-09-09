
namespace WebApplication.Core
{
    public class Picture : Base
    {

        public string Title { get; set; }

        public int EntityId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public string MimeType { get; set; }

        public int Size { get; set; }

        public bool IsDefault { get; set; }
    }
}