
using System;
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Area.Admin.Models
{
    public class GalleryModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [UIHint("SessionId")]
        public int SessionId { get; set; }
        public string SessionName { get; set; }

        [UIHint("Date")]
        public DateTime EventDate { get; set; }

        [MaxLength(100)]
        [UIHint("MultilineText")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }
    }
}