using System.Collections.Generic;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public interface ICircularsRepository : IRepository<Circulars>
    {
        List<Circulars> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

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
