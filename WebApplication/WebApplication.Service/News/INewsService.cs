
using System.Collections.Generic;
using System.Web;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface INewsService : IService<News, int>
    {
        List<News> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
        List<ViewDataUploadFilesResult> Upload(HttpContextBase httpContext, string path);
    }
}
