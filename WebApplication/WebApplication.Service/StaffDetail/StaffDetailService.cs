using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class StaffDetailService : IStaffDetailService
    {
        private StaffDetailRepository staffDetailRepository;
        public StaffDetailService()
        {
            staffDetailRepository = new StaffDetailRepository();
        }

        public bool DeleteById(StaffDetail obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = staffDetailRepository.DeleteById(obj.Id);
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
                result = staffDetailRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(StaffDetail obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public StaffDetail GetById(StaffDetail obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public StaffDetail GetById(int Id, long currentUserId)
        {
            StaffDetail obj = new StaffDetail();
            try
            {
                obj = staffDetailRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<StaffDetail> GetByIdAsync(StaffDetail obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<StaffDetail> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<StaffDetail> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<StaffDetail> list = new List<StaffDetail>();
            try
            {
                list = staffDetailRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<StaffDetail> GetList(long currentUserId)
        {
            List<StaffDetail> list = new List<StaffDetail>();

            try
            {
                list = staffDetailRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<StaffDetail>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = staffDetailRepository.GetListCount(pageNo, pageSize);
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
                result = staffDetailRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(StaffDetail obj)
        {
            int result = 0;
            try
            {
                result = staffDetailRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<StaffDetail> SaveAsync(StaffDetail obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
