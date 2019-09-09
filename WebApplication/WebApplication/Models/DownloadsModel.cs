using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class DownloadsModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Class")]
        [UIHint("ClassMasterRomanId")]
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }

        [UIHint("Date")]
        public DateTime Date { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "File")]
        [DataType(DataType.Upload)]
        public string FileName { get; set; }

        [Display(Name = "Is Publish")]
        public bool IsPublish { get; set; }


        public int SortId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }
    }
}