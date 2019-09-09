using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class DownloadsExtension
    {
        public static DownloadsModel ToModel(this Downloads obj)
        {
            return Mapper.Map<Downloads, DownloadsModel>(obj);
        }

        public static List<DownloadsModel> ToModel(this List<Downloads> objList)
        {
            return Mapper.Map<List<Downloads>, List<DownloadsModel>>(objList);
        }

        public static Downloads ToEntity(this DownloadsModel model)
        {
            return Mapper.Map<DownloadsModel, Downloads>(model);
        }

        public static List<Downloads> ToEntity(this List<DownloadsModel> objList)
        {
            return Mapper.Map<List<DownloadsModel>, List<Downloads>>(objList);
        }
    }
}