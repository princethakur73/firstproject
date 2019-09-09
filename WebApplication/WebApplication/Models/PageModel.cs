using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class PageModel
    {
        public int Id { get; set; }

        public string MenuCode { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(150)]
        public string Seo { get; set; }

        [StringLength(250)]
        [UIHint("MultilineText")]
        public string MetaKeywords { get; set; }

        [StringLength(300)]
        [UIHint("MultilineText")]
        public string MetaDescription { get; set; }

        [StringLength(200)]
        public string MetaTitle { get; set; }

        [UIHint("RichEditor")]
        [AllowHtml]
        public string Contents { get; set; }

        public bool IsPublish { get; set; }

        public int UserId { get; set; }
    }
}