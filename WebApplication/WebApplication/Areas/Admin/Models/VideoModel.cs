
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Area.Admin.Models
{
    public class VideoModel
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Title { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public int UserId { get; set; }
    }
}