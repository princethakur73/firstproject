using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class AdmissionViewModel
    {
        public List<StudentAdmissionModel> StudentAdmissionModels { get; set; }

        public Pager Pager { get; set; }
    }
}