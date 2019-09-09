using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class MemberModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Desigination { get; set; }

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