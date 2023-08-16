using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApplication.Core.Model
{
    public class RecruitmentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [RegularExpression(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$", ErrorMessage = "Use letters only please")]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage = "DOB Required")]
        public string DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        [MaxLength(12)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Contact must be numeric")]
        [Required(ErrorMessage = "Contact Required")]
        public string Contact { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ApplyFor { get; set; }
        [Required(ErrorMessage = "Resume/CV Required")]
        public HttpPostedFileBase RecruitmentFile { get; set; }
        public string RecruitmentTemplatePath { get; set; }
        public string ConfirmationTemplatePath { get; set; }
    }
}
