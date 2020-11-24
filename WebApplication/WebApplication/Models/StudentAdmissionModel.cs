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
        public string DOB { get; set; }
        [Required]
        public string DOBInWords { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        
        public string Address { get; set; }
        
        public string Contact { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string LastBoard { get; set; }
        [Required]
        public string LastSchool { get; set; }       
        [Required]
        [Display(Name = "Class")]
        [UIHint("ClassMasterRomanId")]
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }
        public int SortId { get; set; }
        public int RemoveImage { get; set; } = 0;
        public string Image { get; set; }

        ///////////////
        public string FatherEducation { get; set; }
        public string MotherEducation { get; set; }
        public string FatherAddress { get; set; }
        public string MotherAddress { get; set; }
        public string FatherEmail { get; set; }
        public string MotherEmail { get; set; }
        public string FatherOfficialAddress { get; set; }
        public string MotherOfficialAddress { get; set; }
        public string FatherAnnualIncome { get; set; }
        public string MotherAnnualIncome { get; set; }
        public string IsSingleGirl { get; set; }
        public string IsSpecialAbled { get; set; }
        public string IsEBS { get; set; }
        public string AadharNo { get; set; }
        public string TransferCertificateNumber { get; set; }
        public string DateOfIssue { get; set; }
        public string Subject { get; set; }
        public string MaxMarks { get; set; }
        public string MarksObtained { get; set; }
        public string PercentageMarks { get; set; }
        public string Remarks { get; set; }
        public string SiblingName { get; set; }
        public string SiblingRelation { get; set; }
        public string SiblingAge { get; set; }
        public string SiblingSchool { get; set; }
        public string Date { get; set; }
        public string Place { get; set; }
        public string RelationWithCandidate { get; set; }
    }
}