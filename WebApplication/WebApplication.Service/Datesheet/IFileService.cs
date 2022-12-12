
using System.Collections.Generic;
using System.Web;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface IFileService : IService<File, int>
    {
        List<File> GetList(int pageNo = 1, int pageSize = 10, int type = 0);
        int GetListCount(int pageNo = 1, int pageSize = 10, int type = 0);
        List<ViewDataUploadFilesResult> Upload(HttpContextBase httpContext, string path);
    }
}
