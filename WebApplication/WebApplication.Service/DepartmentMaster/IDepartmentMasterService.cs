﻿using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface IDepartmentMasterService : IService<DepartmentMaster, int>
    {
        List<DepartmentMaster> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
    }
}
