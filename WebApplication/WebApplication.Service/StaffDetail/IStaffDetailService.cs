using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Core.Model;

namespace WebApplication.Service
{
    public interface IStaffDetailService : IService<StaffDetail, int>
    {
        List<StaffDetail> GetList(string staffName="",int pageNo = 1, int pageSize = 10);

        int GetListCount(string staffName= "",int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
        List<DepartmentStaffModel> GetStaffList();
    }
}
