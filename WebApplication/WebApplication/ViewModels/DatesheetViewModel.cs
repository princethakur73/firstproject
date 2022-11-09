using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class DatesheetViewModel
    {
        public List<DatesheetModel> DatesheetModels { get; set; }

        public Pager Pager { get; set; }
    }
}