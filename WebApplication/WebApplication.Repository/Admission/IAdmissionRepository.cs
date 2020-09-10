using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public interface IAdmissionRepository : IRepository<StudentAdmission>
    {
        List<StudentAdmission> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
    }
}
