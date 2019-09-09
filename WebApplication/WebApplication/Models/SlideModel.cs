using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class SlideModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Image { get; set; }

        public bool IsActive { get; set; }

        public int SortId { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }
    }
}