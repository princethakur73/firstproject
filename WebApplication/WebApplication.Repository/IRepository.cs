
using System.Collections.Generic;
namespace WebApplication.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll(long currentUserId);

        T GetById(int id);

        int Save(T obj);

        bool DeleteById(int id);



    }
}
