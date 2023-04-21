using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public interface ICircularsRepository : IRepository<Circulars>
    {
        List<Circulars> GetList(int year, int pageNumber = 0, int pageSize = 0);

        int GetListCount(int year);

        bool IsNameExist(string name, int id);

        #region PTM
        Ptm GetByIdPtm(int? id);
        int SavePTM(Core.Ptm obj);
        bool DeleteByIdPtm(int id);
        bool IsNameExistPtm(string name, int id);
        List<Ptm> GetListPtm(int pageNo = 1, int pageSize = 10);
        #endregion
    }
}
