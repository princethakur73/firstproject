using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class DatesheetService : IDatesheetService
    {
        private DatesheetRepository datesheetRepository;
        public DatesheetService()
        {
            datesheetRepository = new DatesheetRepository();
        }

        public int Save(Datesheet obj)
        {
            int result = 0;
            try
            {
                result = datesheetRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Datesheet GetById(int Id, long currentUserId)
        {
            Datesheet obj = new Datesheet();
            try
            {
                obj = datesheetRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public List<Datesheet> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Datesheet> list = new List<Datesheet>();
            try
            {
                list = datesheetRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }
        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = datesheetRepository.GetListCount(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return count;
        }

        public bool DeleteById(int Id, long currentUserId)
        {
            bool result = false;
            try
            {
                result = datesheetRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }
        ///////////////
        public List<ViewDataUploadFilesResult> Upload(HttpContextBase httpContext, string path)
        {
            var resultList = new List<ViewDataUploadFilesResult>();
            List<ViewDataUploadFilesResult> list = new List<ViewDataUploadFilesResult>();
            FilesHelper photoFilesHelper = new FilesHelper(path);
            var CurrentContext = httpContext;
            photoFilesHelper.UploadFiles(CurrentContext, resultList, new string[] { ".jpeg", ".jpg", ".png" });
            return resultList;
        }

        public Task<IEnumerable<Datesheet>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<Datesheet> GetList(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Datesheet> GetByIdAsync(Datesheet obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Datesheet> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Datesheet GetById(Datesheet obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(Datesheet obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(Datesheet obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Datesheet> SaveAsync(Datesheet obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
