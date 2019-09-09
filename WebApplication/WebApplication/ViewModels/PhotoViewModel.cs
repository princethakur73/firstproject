using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.ViewModels
{
    public class PhotoViewModel
    {
        public Gallery Gallery { get; set; }

        public List<ViewDataUploadFilesResult> Photos { get; set; }
    }
}