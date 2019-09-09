using System.Collections.Generic;
using WebApplication.Area.Admin.Models;
using WebApplication.Core.Common;

namespace WebApplication.ViewModels
{
    public class GalleryViewModel
    {
        public List<GalleryModel> GalleryModels { get; set; }

        public Pager Pager { get; set; }
    }
}