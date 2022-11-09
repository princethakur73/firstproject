
using System.Collections.Generic;
using System.Web;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface IDatesheetService : IService<Datesheet, int>
    {
        List<Datesheet> GetList(int pageNo = 1, int pageSize = 10);
        int GetListCount(int pageNo = 1, int pageSize = 10);
        List<ViewDataUploadFilesResult> Upload(HttpContextBase httpContext, string path);
    }
}
