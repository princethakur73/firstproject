using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core
{
    public class StudentAdmission : Base
    {
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string DOBInWords { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Category { get; set; }
        public string LastBoard { get; set; }
        public string LastSchool { get; set; }        
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int SortId { get; set; }
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
        public DateTime DateOfIssue { get; set; }
        public string Subject { get; set; }
        public string MaxMarks { get; set; }
        public string MarksObtained { get; set; }
        public string PercentageMarks { get; set; }
        public string Remarks { get; set; }
        public string SiblingName { get; set; }
        public string SiblingRelation { get; set; }
        public string SiblingAge { get; set; }
        public string SiblingSchool { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string RelationWithCandidate { get; set; }
    }
}