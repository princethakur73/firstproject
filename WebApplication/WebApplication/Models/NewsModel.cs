using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        public string Key { get; set; }

        [UIHint("Date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string FileName { get; set; }
        public bool IsRemoveFile { get; set; }
        
        [MaxLength(200)]
        [Display(Name = "Short Description")]
        [UIHint("MultilineText")]
        public string ShortDescription { get; set; }

        [UIHint("RichEditor")]
        [AllowHtml]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int SortId { get; set; }

        public int Views { get; set; }

        public int UserId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }

    }
}