﻿using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public interface IDepartmentMasterRepository : IRepository<DepartmentMaster>
    {
        List<DepartmentMaster> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
    }
}
