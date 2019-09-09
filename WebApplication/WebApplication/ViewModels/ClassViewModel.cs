using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class ClassViewModel
    {
        public List<ClassModel> ClassModels { get; set; }

        public Pager Pager { get; set; }
    }
}