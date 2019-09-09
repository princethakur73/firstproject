
using System;
using System.Collections.Generic;
namespace WebApplication.Core
{
    public class Gallery : Base
    {
        public string Name { get; set; }

        public int SessionId { get; set; }
        public string SessionName { get; set; }

        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<GalleryPicture> Photos { get; set; }

        public IEnumerable<GalleryVideo> Videos { get; set; }

        public List<ViewDataUploadFilesResult> ViewDataUploadFilesResults { get; set; }
    }
}