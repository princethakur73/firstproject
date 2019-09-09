using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public interface IClassMasterRepository : IRepository<ClassMaster>
    {
        List<ClassMaster> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
    }
}
