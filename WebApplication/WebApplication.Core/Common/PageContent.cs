namespace WebApplication.Core.Common
{
    public class PageContent : Base
    {
        public int PageId { get; set; }

        public string Type { get; set; }

        public string Contents { get; set; }

        public int SortId { get; set; }
    }
}
