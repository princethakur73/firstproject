using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Helpers;

namespace WebApplication
{
    public static class GalleryPictureExtension
    {
        public static ViewDataUploadFilesResult ToModel(this GalleryPicture obj)
        {
            return Mapper.Map<GalleryPicture, ViewDataUploadFilesResult>(obj);
        }

        public static List<ViewDataUploadFilesResult> ToModel(this List<GalleryPicture> objList)
        {
            return Mapper.Map<List<GalleryPicture>, List<ViewDataUploadFilesResult>>(objList);
        }

        public static GalleryPicture ToEntity(this ViewDataUploadFilesResult model)
        {
            return Mapper.Map<ViewDataUploadFilesResult, GalleryPicture>(model);
        }

        public static List<GalleryPicture> ToEntity(this List<ViewDataUploadFilesResult> objList)
        {
            return Mapper.Map<List<ViewDataUploadFilesResult>, List<GalleryPicture>>(objList);
        }
    }
}