using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class AdmissionService : IAdmissionService
    {
        private AdmissionRepository AdmissionRepository;
        public AdmissionService()
        {
            AdmissionRepository = new AdmissionRepository();
        }

        public bool DeleteById(StudentAdmission obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = AdmissionRepository.DeleteById(obj.Id);
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
                result = AdmissionRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(StudentAdmission obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public StudentAdmission GetById(StudentAdmission obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public StudentAdmission GetById(int Id, long currentUserId)
        {
            StudentAdmission obj = new StudentAdmission();
            try
            {
                obj = AdmissionRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<StudentAdmission> GetByIdAsync(StudentAdmission obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<StudentAdmission> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<StudentAdmission> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<StudentAdmission> list = new List<StudentAdmission>();
            try
            {
                list = AdmissionRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<StudentAdmission> GetList(long currentUserId)
        {
            List<StudentAdmission> list = new List<StudentAdmission>();

            try
            {
                list = AdmissionRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<StudentAdmission>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = AdmissionRepository.GetListCount(pageNo, pageSize);
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
                result = AdmissionRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(StudentAdmission obj)
        {
            int result = 0;
            try
            {
                result = AdmissionRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<StudentAdmission> SaveAsync(StudentAdmission obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
