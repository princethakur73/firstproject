using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Area.Admin.Models
{
    public class SettingModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreateByDate { get; set; }

        [ScaffoldColumn(false)]
        public int CreateByUserId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime ModifyByDate { get; set; }

        [ScaffoldColumn(false)]
        public int ModifyByUserId { get; set; }
    }
}