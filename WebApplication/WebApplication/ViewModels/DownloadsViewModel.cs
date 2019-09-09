using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class DownloadsViewModel
    {
        public List<DownloadsModel> DownloadsModels { get; set; }

        public Pager Pager { get; set; }
    }
}