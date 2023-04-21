using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Core.Model;

namespace WebApplication.Service
{
    public interface IAdmissionService : IService<StudentAdmission, int>
    {
        List<StudentAdmission> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);
        bool SubmitRecruitmentForm(RecruitmentModel model);
    }
}
