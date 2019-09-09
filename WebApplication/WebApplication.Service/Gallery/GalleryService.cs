using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Core;
using WebApplication.Repository;

namespace WebApplication.Service
{
    public class GalleryService : IGalleryService
    {
        private GalleryRepository GalleryRepository;
        public GalleryService()
        {
            GalleryRepository = new GalleryRepository();
        }

        public bool DeleteById(Gallery obj, long currentUserId)
        {
            bool result = false;
            try
            {
                result = GalleryRepository.DeleteById(obj.Id);
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
                result = GalleryRepository.DeleteById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return result;
        }

        public Task<bool> DeleteByIdAsync(Gallery obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteGalleryPhotoById(int? pictureId)
        {
            bool result = false;
            try
            {
                result = GalleryRepository.DeleteGalleryPhotoById(pictureId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public bool DeleteGalleryPhotoByName(string file)
        {
            bool result = false;
            try
            {
                result = GalleryRepository.DeleteGalleryPhotoByName(file);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public bool DeleteGalleryVideoByName(string file)
        {
            bool result = false;
            try
            {
                result = GalleryRepository.DeleteGalleryVideoByName(file);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Gallery GetById(Gallery obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Gallery GetById(int Id, long currentUserId)
        {
            Gallery obj = new Gallery();
            try
            {
                obj = GalleryRepository.GetById(Id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return obj;
        }

        public Task<Gallery> GetByIdAsync(Gallery obj, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Gallery> GetByIdAsync(int Id, long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Gallery>> GetGalleryBySessionNameAsync(string sessionName)
        {
            IEnumerable<Gallery> list;

            try
            {
                list = await GalleryRepository.GetGalleryBySessionNameAsync(sessionName);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<ViewDataUploadFilesResult> GetGalleryPhotosByGalleryId(int? galleryId)
        {
            List<ViewDataUploadFilesResult> list = new List<ViewDataUploadFilesResult>();
            try
            {
                list = GalleryRepository.GetGalleryPhotosByGalleryId(galleryId);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public async Task<Gallery> GetGalleryPhotosByGalleryIdAsync(int galleryId)
        {
            Gallery data = new Gallery();

            try
            {
                data = await GalleryRepository.GetGalleryPhotosByGalleryIdAsync(galleryId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return data;
        }

        public async Task<Gallery> GetGalleryVideoByGalleryIdAsync(int galleryId)
        {
            Gallery data = new Gallery();

            try
            {
                data = await GalleryRepository.GetGalleryVideoByGalleryIdAsync(galleryId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return data;
        }

        public List<ViewDataUploadFilesResult> GetGalleryVideosByGalleryId(int? galleryId)
        {
            List<ViewDataUploadFilesResult> list = new List<ViewDataUploadFilesResult>();
            try
            {
                list = GalleryRepository.GetGalleryVideosByGalleryId(galleryId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<Gallery> GetList(int pageNo = 1, int pageSize = 10)
        {
            List<Gallery> list = new List<Gallery>();
            try
            {
                list = GalleryRepository.GetList(pageNo, pageSize);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<Gallery> GetList(long currentUserId)
        {
            List<Gallery> list = new List<Gallery>();

            try
            {
                list = GalleryRepository.GetAll(currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public Task<IEnumerable<Gallery>> GetListAsync(long currentUserId)
        {
            throw new System.NotImplementedException();
        }

        public int GetListCount(int pageNo = 1, int pageSize = 10)
        {
            int count = 0;
            try
            {
                count = GalleryRepository.GetListCount(pageNo, pageSize);
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
                result = GalleryRepository.IsNameExist(name, id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public int Save(Gallery obj)
        {
            int result = 0;
            try
            {
                result = GalleryRepository.Save(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            return result;
        }

        public Task<Gallery> SaveAsync(Gallery obj)
        {
            throw new System.NotImplementedException();
        }

        public List<ViewDataUploadFilesResult> SavePhotos(HttpContextBase httpContext, string mediaUploadType, int currentUserId)
        {
            List<ViewDataUploadFilesResult> list = new List<ViewDataUploadFilesResult>();
            try
            {
                list = GalleryRepository.SavePhotos(httpContext, mediaUploadType, currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }

        public List<ViewDataUploadFilesResult> SaveVideos(HttpContextBase httpContext, string mediaUploadType, int currentUserId)
        {
            List<ViewDataUploadFilesResult> list = new List<ViewDataUploadFilesResult>();
            try
            {
                list = GalleryRepository.SaveVideos(httpContext, mediaUploadType, currentUserId);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
            return list;
        }
    }
}
