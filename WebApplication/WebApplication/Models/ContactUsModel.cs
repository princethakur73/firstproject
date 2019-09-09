using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ContactUsModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserIPAddress { get; set; }

    }
}