using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface ICircularsService : IService<Circulars, int>
    {
        List<Circulars> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
    }
}
