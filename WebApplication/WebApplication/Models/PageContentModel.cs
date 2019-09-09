using System;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class PageContentModel
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public string Type { get; set; }

        [AllowHtml]
        public string Contents { get; set; }

        public int SortId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }
    }
}