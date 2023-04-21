using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication.Core.Model
{
    public class RecruitmentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage ="DOB Required")]
        public string DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage ="Invalid email address")]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact Required")]
        public string Contact { get; set; }
        [Required]
        public string ApplyFor { get; set; }
        [Required(ErrorMessage = "Resume/CV Required")]
        public HttpPostedFileBase RecruitmentFile { get; set; }
        public string RecruitmentTemplatePath { get; set; }
        public string ConfirmationTemplatePath { get; set; }
    }
}
