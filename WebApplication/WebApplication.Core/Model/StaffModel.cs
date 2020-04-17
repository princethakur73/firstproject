using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Core.Model
{
    public class StaffModel
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string AcadmicQualification { get; set; }
        public bool IsActive { get; set; }
    }
    public class DepartmentStaffModel
    {
        public string Department { get; set; }
        public List<StaffModel> Staff { get; set; }
    }
}
