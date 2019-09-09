using WebApplication.Core.Common;

namespace WebApplication.Service
{
    public interface IPageService : IService<Page, int>
    {
        Page GetPageByMenuCode(string menuCode);
    }
}
