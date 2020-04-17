﻿using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Core.Model;

namespace WebApplication.Repository
{
    public interface IStaffDetailRepository : IRepository<StaffDetail>
    {
        List<StaffDetail> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
        List<StaffModel> GetStaffList();
    }
}
