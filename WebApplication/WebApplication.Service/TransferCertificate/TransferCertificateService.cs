using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class TransferCertificateService : ITransferCertificateService
    {
        private TransferCertificateRepository TransferCertificateRepository;
        public TransferCertificateService()
        {
            TransferCertificateRepository = new TransferCertificateRepository();
        }

        public bool DeleteById(TransferCerticate obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = TransferCertificateRepository.DeleteById(obj.Id);
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
                result = TransferCertificateRepository.DeleteById(Id);
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

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public TransferCerticate GetById(TransferCerticate obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public TransferCerticate GetById(int Id, long currentUserId)
        {
            TransferCerticate obj = new TransferCerticate();
            try
            {
                obj = TransferCertificateRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<TransferCerticate> GetByIdAsync(TransferCerticate obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TransferCerticate> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<TransferCerticate> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<TransferCerticate> list = new List<TransferCerticate>();
            try
            {
                list = TransferCertificateRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }



        public List<TransferCerticate> GetList(long currentUserId)
        {
            List<TransferCerticate> list = new List<TransferCerticate>();

            try
            {
                list = TransferCertificateRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<TransferCerticate>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = TransferCertificateRepository.GetListCount(pageNo, pageSize);
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
                result = TransferCertificateRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(TransferCerticate obj)
        {
            int result = 0;
            try
            {
                result = TransferCertificateRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<TransferCerticate> SaveAsync(TransferCerticate obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
