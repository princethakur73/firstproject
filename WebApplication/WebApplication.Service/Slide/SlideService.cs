using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class SlideService : ISlideService
    {
        private SlideRepository SlideRepository;
        public SlideService()
        {
            SlideRepository = new SlideRepository();
        }

        public bool DeleteById(Slide obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = SlideRepository.DeleteById(obj.Id);
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
                result = SlideRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(Slide obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Slide GetById(Slide obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Slide GetById(int Id, long currentUserId)
        {
            Slide obj = new Slide();
            try
            {
                obj = SlideRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<Slide> GetByIdAsync(Slide obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Slide> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<Slide> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Slide> list = new List<Slide>();
            try
            {
                list = SlideRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<Slide> GetList(long currentUserId)
        {
            List<Slide> list = new List<Slide>();

            try
            {
                list = SlideRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<Slide>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = SlideRepository.GetListCount(pageNo, pageSize);
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
                result = SlideRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(Slide obj)
        {
            int result = 0;
            try
            {
                result = SlideRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<Slide> SaveAsync(Slide obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
