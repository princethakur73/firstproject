using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Core.Common;

namespace WebApplication.Repository
{
    public interface ICommonRepository
    {
        List<UserMenu> GetUserMenuByUserId(int userId);

        List<Session> GetSessionList();

        List<Session> GetGallerySessionList();

        Session GetSessionByName(string sessionName);
    }
}
