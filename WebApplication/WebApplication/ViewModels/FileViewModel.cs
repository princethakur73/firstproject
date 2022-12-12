using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class FileViewModel
    {
        public List<FileTypeModel> FileModels { get; set; }

        public Pager Pager { get; set; }
    }
}