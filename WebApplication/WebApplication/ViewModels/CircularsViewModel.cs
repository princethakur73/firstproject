using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class CircularsViewModel
    {
        public List<CircularsModel> CircularsModels { get; set; }

        public Pager Pager { get; set; }
    }
}