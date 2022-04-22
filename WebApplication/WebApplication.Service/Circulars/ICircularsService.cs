using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface ICircularsService : IService<Circulars, int>
    {
        List<Circulars> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);

        #region PTM
        List<Ptm> GetListPtm(int pageNo = 1, int pageSize = 10);
        Ptm GetByIdPtm(int? Id);
        int SavePtm(Ptm obj);
        bool DeletePtmById(int Id);
        #endregion
    }
}
