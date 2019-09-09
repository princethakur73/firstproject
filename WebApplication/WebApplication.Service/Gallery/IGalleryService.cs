using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using WebApplication.Core;

namespace WebApplication.Service
{
    public interface IGalleryService : IService<Gallery, int>
    {
        List<Gallery> GetList(int pageNo = 1, int pageSize = 10);

        int GetListCount(int pageNo = 1, int pageSize = 10);

        bool IsNameExist(string name, int id);

        List<ViewDataUploadFilesResult> SavePhotos(HttpContextBase httpContext, string mediaUploadType, int currentUserId);

        List<ViewDataUploadFilesResult> GetGalleryPhotosByGalleryId(int? galleryId);

        bool DeleteGalleryPhotoById(int? pictureId);

        bool DeleteGalleryPhotoByName(string file);

        List<ViewDataUploadFilesResult> SaveVideos(HttpContextBase httpContext, string mediaUploadType, int currentUserId);

        List<ViewDataUploadFilesResult> GetGalleryVideosByGalleryId(int? galleryId);

        bool DeleteGalleryVideoByName(string file);

        Task<IEnumerable<Gallery>> GetGalleryBySessionNameAsync(string sessionName);

        Task<Gallery> GetGalleryPhotosByGalleryIdAsync(int galleryId);

        Task<Gallery> GetGalleryVideoByGalleryIdAsync(int galleryId);
    }
}
