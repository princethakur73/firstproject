using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication.Service
{
    public interface IService<TObject, TId>
    {
        Task<IEnumerable<TObject>> GetListAsync(long currentUserId);

        List<TObject> GetList(long currentUserId);

        Task<TObject> GetByIdAsync(TObject obj, long currentUserId);

        Task<TObject> GetByIdAsync(TId Id, long currentUserId);

        TObject GetById(TObject obj, long currentUserId);

        TObject GetById(TId Id, long currentUserId);

        Task<bool> DeleteByIdAsync(TObject obj, long currentUserId);

        Task<bool> DeleteByIdAsync(TId Id, long currentUserId);

        bool DeleteById(TObject obj, long currentUserId);

        bool DeleteById(TId Id, long currentUserId);

        Task<TObject> SaveAsync(TObject obj);

        TId Save(TObject obj);
    }
}
