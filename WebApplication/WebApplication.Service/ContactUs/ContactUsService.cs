using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class ContactUsService : IContactUsService
    {
        private ContactUsRepository ContactUsRepository;
        public ContactUsService()
        {
            ContactUsRepository = new ContactUsRepository();
        }

        public bool DeleteById(ContactUs obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = ContactUsRepository.DeleteById(obj.Id);
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
                result = ContactUsRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(ContactUs obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public ContactUs GetById(ContactUs obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public ContactUs GetById(int Id, long currentUserId)
        {
            ContactUs obj = new ContactUs();
            try
            {
                obj = ContactUsRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<ContactUs> GetByIdAsync(ContactUs obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ContactUs> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<ContactUs> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<ContactUs> list = new List<ContactUs>();
            try
            {
                list = ContactUsRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<ContactUs> GetList(long currentUserId)
        {
            List<ContactUs> list = new List<ContactUs>();

            try
            {
                list = ContactUsRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<ContactUs>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = ContactUsRepository.GetListCount(pageNo, pageSize);
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
                result = ContactUsRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(ContactUs obj)
        {
            int result = 0;
            try
            {
                result = ContactUsRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<ContactUs> SaveAsync(ContactUs obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
