using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ToppersModel
    {
        public int Id { get; set; }

        [UIHint("ClassMasterId")]
        [Required]
        [Display(Name = "Class Name")]
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CGPA { get; set; }

        public int RemoveImage { get; set; } = 0;
        public string Image { get; set; }

        public int SortId { get; set; }

        public int UserId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }
    }
}