using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class StaffDetailModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Group Name")]
        public string GroupId { get; set; }

        public Int16 RemoveImage { get; set; } = 0;
        public string Image { get; set; }

        [Required]
        public string Desigination { get; set; }

        [UIHint("Date")]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Professional Qualification")]
        public string ProfessionalQualification { get; set; }

        [Display(Name = "Academic Qualification")]
        public string AcadmicQualification { get; set; }

        [Required]
        [Display(Name = "Training Status")]
        public string TrainingStatus { get; set; }

        [Required]
        [Display(Name = "Job Status")]
        public string JobStatus { get; set; }

        [Display(Name = "Sort Id")]
        public int SortId { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }

        public int UserId { get; set; }
    }
}