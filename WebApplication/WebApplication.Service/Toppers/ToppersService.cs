using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class ToppersService : IToppersService
    {
        private ToppersRepository ToppersRepository;
        public ToppersService()
        {
            ToppersRepository = new ToppersRepository();
        }

        public bool DeleteById(Toppers obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = ToppersRepository.DeleteById(obj.Id);
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
                result = ToppersRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(Toppers obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Toppers GetById(Toppers obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Toppers GetById(int Id, long currentUserId)
        {
            Toppers obj = new Toppers();
            try
            {
                obj = ToppersRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<Toppers> GetByIdAsync(Toppers obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Toppers> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<Toppers> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Toppers> list = new List<Toppers>();
            try
            {
                list = ToppersRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<Toppers> GetList(long currentUserId)
        {
            List<Toppers> list = new List<Toppers>();

            try
            {
                list = ToppersRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<Toppers>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = ToppersRepository.GetListCount(pageNo, pageSize);
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
                result = ToppersRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(Toppers obj)
        {
            int result = 0;
            try
            {
                result = ToppersRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<Toppers> SaveAsync(Toppers obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
