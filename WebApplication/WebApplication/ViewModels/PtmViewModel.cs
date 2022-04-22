using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class PtmViewModel
    {
        public List<PtmModel> PtmModels { get; set; }

        public Pager Pager { get; set; }
    }
}