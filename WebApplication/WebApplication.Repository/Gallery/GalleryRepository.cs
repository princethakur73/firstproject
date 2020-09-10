using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using WebApplication.Core;

namespace WebApplication.Repository
{
    public class GalleryRepository : IGalleryRepository
    {
        private string query { get; set; }

        FilesHelper photoFilesHelper;
        FilesHelper videoFilesHelper;
        string tempPath = "~/Gallery/";
        string serverMapPath = "~/Files/Gallery/";
        private string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }
        private string UrlBase = "/Files/Gallery/";
        string DeleteURL = "/Admin/Gallery/Delete{0}File?file=";
        string DeleteType = "GET";

        public GalleryRepository()
        {
            photoFilesHelper = new FilesHelper(string.Format(DeleteURL, "Photo"), DeleteType, StorageRoot, string.Concat(UrlBase, "photos/"), string.Concat(tempPath, "photos/"), string.Concat(serverMapPath, "photos/"));
            videoFilesHelper = new FilesHelper(string.Format(DeleteURL, "Video"), DeleteType, StorageRoot, string.Concat(UrlBase, "videos/"), string.Concat(tempPath, "videos/"), string.Concat(serverMapPath, "videos/"));
        }

        public List<Core.Gallery> GetAll(long currentUserId)
        {
            List<Gallery> list;
            try
            {
                query = @"Select Id,
			                    Name, 		
                                EventDate,
                                SessionId,
                                s.Name as SessionName,
                                Description,
			                    CreateByDate, 
			                    CreateByUserId,
			                    ModifyByDate, 
			                    ModifyByUserId			                    	   
			                    from Gallery g
                        join session s on 
                        g.sessionId =s.Id and g.IsActive=1 
		                Order By g.Name";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Gallery>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public Core.Gallery GetById(int id)
        {
            Gallery data;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", id, DbType.Int32);
                query = @"Select    g.Id,
			                        g.Name, 	
                                    g.EventDate,
                                    g.SessionId,
                                    s.Name as SessionName,
                                    g.Description,
                                    g.IsActive,
			                        g.CreateByDate, 
			                        g.CreateByUserId,
			                        g.ModifyByDate, 
			                        g.ModifyByUserId			                    
			                    from Gallery g
                         join Session s on g.SessionId=s.Id
		                 where g.Id = @Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    data = Db.Query<Gallery>(query, new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public int Save(Core.Gallery obj)
        {
            int Id = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_Id", obj.Id, DbType.Int32);
                param.Add("_Name", obj.Name, DbType.String);
                param.Add("_SessionId", obj.SessionId, DbType.Int32);
                param.Add("_EventDate", obj.EventDate, DbType.DateTime);
                param.Add("_IsActive", obj.IsActive, DbType.Boolean);
                param.Add("_Description", obj.Description, DbType.String);
                param.Add("_UserId", obj.UserId, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    Id = Db.ExecuteScalar<int>("Sp_Save_Gallery", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return Id;
        }

        public bool DeleteById(int id)
        {
            bool isDeleted = false;
            try
            {
                var photos = GetGalleryPhotosByGalleryId(id);
                var videos = GetGalleryVideosByGalleryId(id);
                int effectedRow = 0;
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    effectedRow = Db.ExecuteScalar<int>("Sp_GalleryDeleteById", param: new { Id = id }, commandType: CommandType.StoredProcedure);
                }
                if (effectedRow > 0)
                {
                    foreach (var item in photos)
                    {
                        photoFilesHelper.DeleteFile(item.name, "Photos");
                    }
                    foreach (var item in videos)
                    {
                        photoFilesHelper.DeleteFile(item.name, "Videos");
                    }
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return isDeleted;
        }

        public bool IsNameExist(string name, int id)
        {
            bool isDeleted = false;
            try
            {
                if (id == 0)
                {
                    query = @"Select count(Id) from Gallery where Name=@Name";
                }
                else
                {
                    query = @"Select count(Id) from Gallery where Name=@Name and Id!=@Id";
                }
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    var effectedRow = Db.ExecuteScalar<int>(query, new { Name = name, Id = id });
                    if (effectedRow > 0)
                        isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return isDeleted;
        }

        public List<Gallery> GetList(int sessionId,int pageNo = 1, int pageSize = 10)
        {
            List<Gallery> list;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_SessionId", sessionId, DbType.Int32);
                param.Add("_IsCount", 0, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = Db.Query<Gallery>("Sp_Select_Gallery_List", param: param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }

        public int GetListCount(int sessionId, int pageNo = 1, int pageSize = 10)
        {
            int countTotal = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("_SessionId", sessionId, DbType.Int32);
                param.Add("_IsCount", 1, DbType.Boolean);
                param.Add("_PageNumber", pageNo, DbType.Int32);
                param.Add("_PageSize", pageSize, DbType.Int32);
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    countTotal = Db.ExecuteScalar<int>("Sp_Select_Gallery_List", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return countTotal;
        }

        public List<ViewDataUploadFilesResult> SavePhotos(HttpContextBase httpContext, string mediaUploadType, int currentUserId)
        {
            var resultList = new List<ViewDataUploadFilesResult>();
            try
            {

                photoFilesHelper = new FilesHelper(string.Format(DeleteURL, "Photo"), DeleteType, string.Concat(StorageRoot, "photos/"), string.Concat(UrlBase, "photos/"), string.Concat(tempPath, "photos/"), string.Concat(serverMapPath, "photos/"));

                var CurrentContext = httpContext;

                photoFilesHelper.UploadAndShowResults(CurrentContext, resultList, new string[] { ".jpeg", ".jpg", ".png" });

                foreach (var photo in resultList)
                {

                    DynamicParameters param = new DynamicParameters();

                    param.Add("_Id", photo.id, DbType.Int32);
                    param.Add("_GalleryId", photo.entityId, DbType.Int32);
                    param.Add("_Title", photo.title, DbType.String);
                    param.Add("_Type", mediaUploadType, DbType.String);
                    param.Add("_Name", mediaUploadType == MediaUploadType.Link ? httpContext.Request.Form["Name"].ToString() : photo.name, DbType.String);
                    param.Add("_Extension", photo.extension, DbType.String);
                    param.Add("_TitleAttribute", photo.titleAttribute, DbType.String);
                    param.Add("_AltAttribute", photo.altAttribute, DbType.String);
                    param.Add("_MimeType", photo.type, DbType.String);
                    param.Add("_Size", photo.size, DbType.Int32);
                    param.Add("_PageId", photo.entityId, DbType.Int32);
                    param.Add("_SortId", 1, DbType.Int32);
                    param.Add("_IsDefault", photo.isDefault, DbType.Boolean);
                    param.Add("_UserId", currentUserId, DbType.Int32);
                    using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                    {
                        int scalar = Db.ExecuteScalar<int>("Sp_Save_Gallery_Picture", param, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return resultList;
        }

        public List<ViewDataUploadFilesResult> GetGalleryPhotosByGalleryId(int? galleryId)
        {
            var r = new List<ViewDataUploadFilesResult>();
            try
            {
                string query = @"Select Id,
                                    Title,
                                    Name,
                                    Type as MediaType,
                                    Extension,
                                    TitleAttribute,
                                    AltAttribute,
                                    MimeType as type,
                                    Size,
                                    IsDefault,
                                    GalleryId as EntityId
                            from picture p 
                            join gallerypicturemapping gpm on p.Id=gpm.PictureId
                            where gpm.GalleryId=@Id";
                var temp = new List<ViewDataUploadFilesResult>();
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    temp = Db.Query<ViewDataUploadFilesResult>(query, new { Id = galleryId }).ToList();
                }
                if (temp != null || temp.Count() == 0)
                {
                    foreach (var item in temp)
                    {
                        var result = new ViewDataUploadFilesResult()
                        {
                            id = item.id,
                            entityId = item.entityId,
                            title = item.title,
                            name = item.MediaType == MediaUploadType.Link ? item.name : item.name + item.extension,
                            extension = item.extension,
                            size = item.size,
                            type = item.type,
                            url = UrlBase + "Photos/" + item.name + item.extension,
                            deleteUrl = item.error == null ? string.Format(DeleteURL, "Photo") + item.id : null,
                            thumbnailUrl = photoFilesHelper.CheckThumb(item.type, item.name + item.extension),
                            deleteType = "GET",
                            altAttribute = item.altAttribute,
                            titleAttribute = item.titleAttribute,
                            error = item.error,
                            MediaType = item.MediaType
                        };
                        r.Add(result);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


            return r;
        }

        public bool DeleteGalleryPhotoById(int? pictureId)
        {
            bool isDeleted = false;
            try
            {
                var data = GetPictureByPictureId(pictureId ?? 0);
                int effectedRow = 0;
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("_Id", pictureId, DbType.String);
                    effectedRow = Db.Execute("Sp_GalleryPictureDeleteById", param, commandType: CommandType.StoredProcedure);
                }

                if (effectedRow > 0)
                {

                    string fileName = data.Name + data.Extension;
                    photoFilesHelper.DeleteFile(fileName, "Photos");
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return isDeleted;
        }

        public bool DeleteGalleryPhotoByName(string file)
        {
            bool isDeleted = false;
            try
            {
                int effectedRow = 0;
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("_Name", file, DbType.String);
                    effectedRow = Db.Execute("Sp_GalleryPictureDeleteByName", param, commandType: CommandType.StoredProcedure);
                }
                if (effectedRow > 0)
                {
                    var data = GetPictureByPictureId(int.Parse(file));
                    string fileName = data.Name + data.Extension;
                    photoFilesHelper.DeleteFile(fileName, "Photos");
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return isDeleted;
        }

        public List<ViewDataUploadFilesResult> SaveVideos(HttpContextBase httpContext, string mediaUploadType, int currentUserId)
        {
            var resultList = new List<ViewDataUploadFilesResult>();
            try
            {

                videoFilesHelper = new FilesHelper(string.Format(DeleteURL, "Video"), DeleteType, string.Concat(StorageRoot, "videos/"), string.Concat(UrlBase, "videos/"), string.Concat(tempPath, "videos/"), string.Concat(serverMapPath, "videos/"));

                var CurrentContext = httpContext;

                videoFilesHelper.UploadAndShowResults(CurrentContext, resultList, new string[] { ".mp4" });
                foreach (var photo in resultList)
                {

                    DynamicParameters param = new DynamicParameters();

                    param.Add("_Id", photo.id, DbType.Int32);
                    param.Add("_GalleryId", photo.entityId, DbType.Int32);
                    param.Add("_Title", photo.title, DbType.String);
                    param.Add("_Type", mediaUploadType, DbType.String);
                    param.Add("_Name", photo.name, DbType.String);
                    param.Add("_Extension", photo.extension, DbType.String);
                    param.Add("_TitleAttribute", photo.titleAttribute, DbType.String);
                    param.Add("_AltAttribute", photo.altAttribute, DbType.String);
                    param.Add("_MimeType", photo.type, DbType.String);
                    param.Add("_Size", photo.size, DbType.Int32);
                    param.Add("_SortId", 1, DbType.Int32);
                    param.Add("_IsDefault", photo.isDefault, DbType.Boolean);
                    param.Add("_UserId", currentUserId, DbType.Int32);

                    using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                    {
                        int scalar = Db.ExecuteScalar<int>("Sp_Save_Gallery_Video", param, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return resultList;
        }

        public List<ViewDataUploadFilesResult> GetGalleryVideosByGalleryId(int? galleryId)
        {
            var r = new List<ViewDataUploadFilesResult>();
            try
            {
                string query = @"Select Id,
                                    Title,
                                    Name,
                                    Extension,
                                    MimeType as type,
                                    Size,                                    
                                    VideoId as EntityId
                            from video p 
                            join galleryvideomapping gvm on p.Id=gvm.videoId
                            where gvm.GalleryId=@Id";
                var temp = new List<ViewDataUploadFilesResult>();
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    temp = Db.Query<ViewDataUploadFilesResult>(query, new { Id = galleryId }).ToList();
                }
                if (temp != null || temp.Count() == 0)
                {
                    foreach (var item in temp)
                    {
                        var result = new ViewDataUploadFilesResult()
                        {
                            entityId = item.entityId,
                            title = item.title,
                            name = item.name + item.extension,
                            extension = item.extension,
                            size = item.size,
                            type = item.type,
                            url = UrlBase + "Videos/" + item.name + item.extension,
                            deleteUrl = item.error == null ? string.Format(DeleteURL, "Video") + item.id : null,
                            thumbnailUrl = photoFilesHelper.CheckThumb(item.type, item.name + item.extension),
                            deleteType = "GET",
                            error = item.error
                        };
                        r.Add(result);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return r;
        }

        public bool DeleteGalleryVideoByName(string file)
        {
            bool isDeleted = false;
            try
            {
                int effectedRow = 0;
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("_Id", int.Parse(file), DbType.Int32);
                    effectedRow = Db.Execute("Sp_GalleryVideoDeleteById", param, commandType: CommandType.StoredProcedure);
                }

                if (effectedRow > 0)
                {
                    photoFilesHelper.DeleteFile(file, "Videos");
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return isDeleted;
        }

        public Picture GetPictureByPictureId(int id)
        {
            Picture data;
            try
            {
                query = @"SELECT Id,
                                Title,
                                Type,
                                Name,
                                Extension,
                                TitleAttribute,
                                AltAttribute,
                                MimeType,
                                Size,
                                PageId,
                                SortId,
                                IsDefault,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                            FROM picture
		                 where Id=@Id";

                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("_Id", id, DbType.Int32);
                    data = Db.Query<Picture>(query, new { Id = id }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public Video GetVideoByVideoId(int id)
        {
            Video data;
            try
            {
                query = @"SELECT Id,
                                Title,
                                Type,
                                Name,
                                Extension,
                                TitleAttribute,
                                AltAttribute,
                                Size,
                                MimeType,
                                IsDefault,
                                CreateByDate,
                                CreateByUserId,
                                ModifyByDate,
                                ModifyByUserId
                            FROM video
		                 where Id=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("_Id", id, DbType.Int32);
                    data = Db.Query<Video>(query, param).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;

        }

        public bool DeleteGalleryVideoById(int? id)
        {
            bool isDeleted = false;
            try
            {
                var data = GetVideoByVideoId(id ?? 0);
                int effectedRow = 0;
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("_Id", id, DbType.Int32);
                    effectedRow = Db.Execute("Sp_GalleryVideoDeleteById", param, commandType: CommandType.StoredProcedure);
                }

                if (effectedRow > 0)
                {

                    string fileName = data.Name + data.Extension;
                    photoFilesHelper.DeleteFile(fileName, "Videos");
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return isDeleted;
        }

        public async Task<IEnumerable<Gallery>> GetGalleryBySessionNameAsync(string sessionName)
        {
            IEnumerable<Gallery> list;
            try
            {
                query = @"Select g.Id,
			                    g.Name, 		
                                g.EventDate,
                                g.SessionId,
                                s.Name as SessionName,
                                g.Description,
			                    g.CreateByDate, 
			                    g.CreateByUserId,
			                    g.ModifyByDate, 
			                    g.ModifyByUserId			                    	   
			                    from Gallery g
                        join session s on 
                        g.sessionId =s.Id
		                where s.Name=@name and g.IsActive=1 
                        order by g.EventDate desc";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    list = await Db.QueryAsync<Gallery>(query, new { name = sessionName });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return list;
        }


        public async Task<Gallery> GetGalleryPhotosByGalleryIdAsync(int galleryId)
        {
            Gallery data;
            try
            {
                query = @"Select g.Id,
			                    g.Name, 		
                                g.EventDate,
                                g.SessionId,
                                s.Name as SessionName,
                                g.Description,
			                    g.CreateByDate, 
			                    g.CreateByUserId,
			                    g.ModifyByDate, 
			                    g.ModifyByUserId			                    	   
			                    from Gallery g
                        join session s on 
                        g.sessionId =s.Id
		                where g.id=@Id and g.IsActive=1 
                        order by g.EventDate desc;
                        
                        Select 	p.Id,
		                        GalleryId,
		                        p.Title,
		                        p.Name,
		                        p.Extension,
		                        p.AltAttribute,
		                        p.TitleAttribute,
		                        p.IsDefault 
                        from picture p
                        join gallerypicturemapping gpm 
                        on p.Id=gpm.GalleryId
                        where GalleryId=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    using (var grid = Db.QueryMultiple(query, new { Id = galleryId }))
                    {
                        data = await grid.ReadSingleOrDefaultAsync<Gallery>();
                        data.Photos = await grid.ReadAsync<GalleryPicture>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }

        public async Task<Gallery> GetGalleryVideoByGalleryIdAsync(int galleryId)
        {
            Gallery data;
            try
            {
                query = @"Select g.Id,
			                    g.Name, 		
                                g.EventDate,
                                g.SessionId,
                                s.Name as SessionName,
                                g.Description,
			                    g.CreateByDate, 
			                    g.CreateByUserId,
			                    g.ModifyByDate, 
			                    g.ModifyByUserId			                    	   
			                    from Gallery g
                        join session s on 
                        g.sessionId =s.Id
		                where g.id=@Id and g.IsActive=1 
                        order by g.EventDate desc;
                        
                        Select 	p.Id,
		                        GalleryId,
		                        p.Title,
		                        p.Name,
		                        p.Extension,
		                        p.AltAttribute,
		                        p.TitleAttribute,
		                        p.IsDefault 
                        from video p
                        join galleryvidemapping gpm 
                        on p.Id=gpm.GalleryId
                        where GalleryId=@Id";
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    using (var grid = Db.QueryMultiple(query, new { Id = galleryId }))
                    {
                        data = await grid.ReadSingleOrDefaultAsync<Gallery>();
                        data.Videos = await grid.ReadAsync<GalleryVideo>();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return data;
        }
        public  int GetCurrentSession()
        {
            try
            {
                query = @"Select  Id from Session Order by Name desc LIMIT 1";               
                using (var Db = new MySqlConnection(DatabaseConnection.ConnectionString))
                {
                    return Db.ExecuteScalar<int>(query);                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
    }
}