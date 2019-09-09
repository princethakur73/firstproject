using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class NewsViewModel
    {
        public List<NewsModel> NewsModels { get; set; }

        public Pager Pager { get; set; }
    }
}