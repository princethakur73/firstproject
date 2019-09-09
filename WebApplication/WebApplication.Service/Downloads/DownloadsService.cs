using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class DownloadsService : IDownloadsService
    {
        private DownloadsRepository DownloadsRepository;
        public DownloadsService()
        {
            DownloadsRepository = new DownloadsRepository();
        }

        public bool DeleteById(Downloads obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = DownloadsRepository.DeleteById(obj.Id);
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
                result = DownloadsRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(Downloads obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Downloads GetById(Downloads obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Downloads GetById(int Id, long currentUserId)
        {
            Downloads obj = new Downloads();
            try
            {
                obj = DownloadsRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<Downloads> GetByIdAsync(Downloads obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Downloads> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<Downloads> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Downloads> list = new List<Downloads>();
            try
            {
                list = DownloadsRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<Downloads> GetList(long currentUserId)
        {
            List<Downloads> list = new List<Downloads>();

            try
            {
                list = DownloadsRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<Downloads>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = DownloadsRepository.GetListCount(pageNo, pageSize);
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
                result = DownloadsRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(Downloads obj)
        {
            int result = 0;
            try
            {
                result = DownloadsRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<Downloads> SaveAsync(Downloads obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
