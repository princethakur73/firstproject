using WebApplication.Core.Common;

namespace WebApplication.Repository
{
    public interface IPageRepository : IRepository<Page>
    {
        Page GetPageByMenuCode(string menuCode);
    }
}
