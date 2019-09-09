using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}