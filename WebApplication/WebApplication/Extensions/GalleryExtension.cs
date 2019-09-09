using AutoMapper;
using System.Collections.Generic;
using WebApplication.Area.Admin.Models;
using WebApplication.Core;

namespace WebApplication
{
    public static class GalleryExtension
    {
        public static GalleryModel ToModel(this Gallery obj)
        {
            return Mapper.Map<Gallery, GalleryModel>(obj);
        }

        public static List<GalleryModel> ToModel(this List<Gallery> objList)
        {
            return Mapper.Map<List<Gallery>, List<GalleryModel>>(objList);
        }

        public static Gallery ToEntity(this GalleryModel model)
        {
            return Mapper.Map<GalleryModel, Gallery>(model);
        }

        public static List<Gallery> ToEntity(this List<GalleryModel> objList)
        {
            return Mapper.Map<List<GalleryModel>, List<Gallery>>(objList);
        }
    }
}