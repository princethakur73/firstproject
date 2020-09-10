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
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FatherOccupation { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Category { get; set; }
        public string LastBoard { get; set; }
        public string LastSchool { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string Subject4 { get; set; }
        public string Subject5 { get; set; }
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public int SortId { get; set; }
    }
}