using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class ClassMasterService : IClassMasterService
    {
        private ClassMasterRepository ClassMasterRepository;
        public ClassMasterService()
        {
            ClassMasterRepository = new ClassMasterRepository();
        }

        public bool DeleteById(ClassMaster obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = ClassMasterRepository.DeleteById(obj.Id);
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
                result = ClassMasterRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(ClassMaster obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public ClassMaster GetById(ClassMaster obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public ClassMaster GetById(int Id, long currentUserId)
        {
            ClassMaster obj = new ClassMaster();
            try
            {
                obj = ClassMasterRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<ClassMaster> GetByIdAsync(ClassMaster obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ClassMaster> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<ClassMaster> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<ClassMaster> list = new List<ClassMaster>();
            try
            {
                list = ClassMasterRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<ClassMaster> GetList(long currentUserId)
        {
            List<ClassMaster> list = new List<ClassMaster>();

            try
            {
                list = ClassMasterRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<ClassMaster>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = ClassMasterRepository.GetListCount(pageNo, pageSize);
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
                result = ClassMasterRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(ClassMaster obj)
        {
            int result = 0;
            try
            {
                result = ClassMasterRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<ClassMaster> SaveAsync(ClassMaster obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
