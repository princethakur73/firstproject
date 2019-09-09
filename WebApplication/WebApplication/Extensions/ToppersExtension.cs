using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class ToppersExtension
    {
        public static ToppersModel ToModel(this Toppers obj)
        {
            return Mapper.Map<Toppers, ToppersModel>(obj);
        }

        public static List<ToppersModel> ToModel(this List<Toppers> objList)
        {
            return Mapper.Map<List<Toppers>, List<ToppersModel>>(objList);
        }

        public static Toppers ToEntity(this ToppersModel model)
        {
            return Mapper.Map<ToppersModel, Toppers>(model);
        }

        public static List<Toppers> ToEntity(this List<ToppersModel> objList)
        {
            return Mapper.Map<List<ToppersModel>, List<Toppers>>(objList);
        }
    }
}