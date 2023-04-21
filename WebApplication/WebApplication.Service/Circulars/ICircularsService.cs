using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface ICircularsService : IService<Circulars, int>
    {
        List<Circulars> GetList(string year = "", int pageNumber = 0, int pageSize = 0);

        int GetListCount(int year);

        bool IsNameExist(string name, int id);

        #region PTM
        List<Ptm> GetListPtm(int pageNo = 1, int pageSize = 10);
        Ptm GetByIdPtm(int? Id);
        int SavePtm(Ptm obj);
        bool DeletePtmById(int Id);
        #endregion
    }
}
