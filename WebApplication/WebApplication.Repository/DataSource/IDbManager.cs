using System.Data;

namespace WebApplication.Repository
{
    public interface IDbManager
    {
        IDbConnection Connection { get; }
    }
}
