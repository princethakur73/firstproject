using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public interface IFileRepository : IRepository<File>
    {
        List<File> GetList(int pageNo = 1, int pageSize = 10,int type=0);
        int GetListCount(int pageNo = 1, int pageSize = 10, int type = 0);
        bool IsNameExist(string name, int id);
    }
}
