using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class ToppersViewModel
    {
        public List<ToppersModel> ToppersModels { get; set; }

        public Pager Pager { get; set; }
    }
}