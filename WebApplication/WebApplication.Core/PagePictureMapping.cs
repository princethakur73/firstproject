using System;

namespace WebApplication.Core
{
    public class PagePictureMapping
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public int PictureId { get; set; }

        public int SortId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }
    }
}
