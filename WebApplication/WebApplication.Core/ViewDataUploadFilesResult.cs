
namespace WebApplication.Core
{
    public class ViewDataUploadFilesResult
    {
        public int id { get; set; }
        public int entityId { get; set; }
        public string MediaType { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string extension { get; set; }
        public string titleAttribute { get; set; }
        public string altAttribute { get; set; }
        public string type { get; set; }
        public bool isDefault { get; set; }
        public int size { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
        public string error { get; set; }
        public int userId { get; set; }
    }
}
