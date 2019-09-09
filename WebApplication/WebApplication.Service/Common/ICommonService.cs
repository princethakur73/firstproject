using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Core.Common;

namespace WebApplication.Service
{
    public interface ICommonService
    {
        List<UserMenu> GetUserMenuByUserId(int userId);

        List<Session> GetSessionList();

        List<Session> GetGellerySessionList();

        Session GetSessionByName(string sessionName);
    }

}
