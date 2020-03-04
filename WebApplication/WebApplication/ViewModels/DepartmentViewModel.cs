using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class DepartmentViewModel
    {
        public List<DepartmentModel> DepartmentModels { get; set; }

        public Pager Pager { get; set; }
    }
}