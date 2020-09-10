using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class StudentAdmissionModel
    {
        public int Id { get; set; }
        [Required]        
        public string StudentName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string LastBoard { get; set; }
        [Required]
        public string LastSchool { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string Subject4 { get; set; }
        public string Subject5 { get; set; }
        [Required]
        [Display(Name = "Class")]
        [UIHint("ClassMasterRomanId")]
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }
        public int SortId { get; set; }
        public int RemoveImage { get; set; } = 0;
        public string Image { get; set; }
    }
}