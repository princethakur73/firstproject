using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class DepartmentMasterService : IDepartmentMasterService
    {
        private DepartmentMasterRepository _departmentMasterRepository;
        public DepartmentMasterService(DepartmentMasterRepository departmentMasterRepository)
        {
            _departmentMasterRepository = departmentMasterRepository;
        }

        public bool DeleteById(DepartmentMaster obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = _departmentMasterRepository.DeleteById(obj.Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public bool DeleteById(int Id, long currentUserId)
        {
            bool result = false;
            try
            {
                result = _departmentMasterRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(DepartmentMaster obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public DepartmentMaster GetById(DepartmentMaster obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public DepartmentMaster GetById(int Id, long currentUserId)
        {
            DepartmentMaster obj = new DepartmentMaster();
            try
            {
                obj = _departmentMasterRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<DepartmentMaster> GetByIdAsync(DepartmentMaster obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<DepartmentMaster> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<DepartmentMaster> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<DepartmentMaster> list = new List<DepartmentMaster>();
            try
            {
                list = _departmentMasterRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<DepartmentMaster> GetList(long currentUserId)
        {
            List<DepartmentMaster> list = new List<DepartmentMaster>();

            try
            {
                list = _departmentMasterRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<DepartmentMaster>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = _departmentMasterRepository.GetListCount(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return count;
        }

        public bool IsNameExist(string name, int id)
        {
            bool result = false;
            try
            {
                result = _departmentMasterRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(DepartmentMaster obj)
        {
            int result = 0;
            try
            {
                result = _departmentMasterRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<DepartmentMaster> SaveAsync(DepartmentMaster obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
