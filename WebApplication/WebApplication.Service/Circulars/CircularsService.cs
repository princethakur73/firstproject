using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class CircularsService : ICircularsService
    {
        private readonly CircularsRepository _circularsRepository;
        public CircularsService(CircularsRepository circularsRepository)
        {
            _circularsRepository = circularsRepository;
        }

        public bool DeleteById(Circulars obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = _circularsRepository.DeleteById(obj.Id);
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
                result = _circularsRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(TransferCerticate obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(Circulars obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Circulars GetById(int Id, long currentUserId)
        {
            Circulars obj = new Circulars();
            try
            {
                obj = _circularsRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Circulars GetById(Circulars obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Circulars> GetByIdAsync(Circulars obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Circulars> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<Circulars> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Circulars> list = new List<Circulars>();
            try
            {
                list = _circularsRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<Circulars> GetList(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Circulars>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = _circularsRepository.GetListCount(pageNo, pageSize);
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
                result = _circularsRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(Circulars obj)
        {
            int result = 0;
            try
            {
                result = _circularsRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<Circulars> SaveAsync(Circulars obj)
        {
            throw new System.NotImplementedException();
        }

        #region PTM
        public List<Ptm> GetListPtm(int pageNo = 1, int pageSize = 10)
        {
            List<Ptm> list = new List<Ptm>();
            try
            {
                list = _circularsRepository.GetListPtm(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }
        public Ptm GetByIdPtm(int? Id)
        {
            Ptm obj = new Ptm();
            try
            {
                obj = _circularsRepository.GetByIdPtm(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public int SavePtm(Ptm obj)
        {
            int result = 0;
            try
            {
                result = _circularsRepository.SavePTM(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }
        public bool DeletePtmById(int Id)
        {
            bool result = false;
            try
            {
                result = _circularsRepository.DeleteByIdPtm(Id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

            return result;
        }
        #endregion
    }
}