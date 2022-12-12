using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class FileService : IFileService
    {
        private FileRepository fileRepository;
        public FileService()
        {
            fileRepository = new FileRepository();
        }

        public int Save(File obj)
        {
            int result = 0;
            try
            {
                result = fileRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public File GetById(int Id, long currentUserId)
        {
            File obj = new File();
            try
            {
                obj = fileRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public List<File> GetList(int pageNo = 1, int pageSize = 10, int type = 0)
        {
            List<File> list = new List<File>();
            try
            {
                list = fileRepository.GetList(pageNo, pageSize, type);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }
        public int GetListCount(int pageNo = 1, int pageSize = 10, int type = 0)
        {
            int count;
            try
            {
                count = fileRepository.GetListCount(pageNo, pageSize, type);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return count;
        }

        public bool DeleteById(int Id, long currentUserId)
        {
            bool result;
            try
            {
                result = fileRepository.DeleteById(Id);
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

        public Task<IEnumerable<File>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public List<File> GetList(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<File> GetByIdAsync(File obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<File> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public File GetById(File obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(File obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(File obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<File> SaveAsync(File obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
