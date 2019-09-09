using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class StaffDetailViewModel
    {
        public List<StaffDetailModel> StaffDetailModels { get; set; }

        public Pager Pager { get; set; }
    }
}