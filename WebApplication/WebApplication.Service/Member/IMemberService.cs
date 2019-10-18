using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface IMemberService : IService<Member, int>
    {
        List<Member> GetList(int pageNo = 1, int pageSize = 10);
        List<Member> GetAllExecutive(long currentUserId);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
    }
}
