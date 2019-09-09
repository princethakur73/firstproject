using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class SlideViewModel
    {
        public List<SlideModel> SlideModels { get; set; }

        public Pager Pager { get; set; }
    }
}