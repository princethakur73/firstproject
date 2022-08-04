using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class NewsService : INewsService
    {
        private NewsRepository NewsRepository;
        public NewsService()
        {
            NewsRepository = new NewsRepository();
        }

        public bool DeleteById(News obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = NewsRepository.DeleteById(obj.Id);
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
                result = NewsRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(News obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public News GetById(News obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public News GetById(int Id, long currentUserId)
        {
            News obj = new News();
            try
            {
                obj = NewsRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<News> GetByIdAsync(News obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<News> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<News> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<News> list = new List<News>();
            try
            {
                list = NewsRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<News> GetList(long currentUserId)
        {
            List<News> list = new List<News>();

            try
            {
                list = NewsRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<News>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = NewsRepository.GetListCount(pageNo, pageSize);
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
                result = NewsRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(News obj)
        {
            int result = 0;
            try
            {
                result = NewsRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<News> SaveAsync(News obj)
        {
            throw new System.NotImplementedException();
        }

        public List<ViewDataUploadFilesResult> Upload(HttpContextBase httpContext, string path)
        {
            var resultList = new List<ViewDataUploadFilesResult>();
            List<ViewDataUploadFilesResult> list = new List<ViewDataUploadFilesResult>();
            FilesHelper photoFilesHelper = new FilesHelper(path);
            var CurrentContext = httpContext;
            photoFilesHelper.UploadFiles(CurrentContext, resultList, new string[] { ".jpeg", ".jpg", ".png" });
            return resultList;
        }
    }
}
