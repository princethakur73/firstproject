using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class CircularsExtension
    {
        public static CircularsModel ToModel(this Circulars obj)
        {
            return Mapper.Map<Circulars, CircularsModel>(obj);
        }

        public static List<CircularsModel> ToModel(this List<Circulars> objList)
        {
            return Mapper.Map<List<Circulars>, List<CircularsModel>>(objList);
        }

        public static Circulars ToEntity(this CircularsModel model)
        {
            return Mapper.Map<CircularsModel, Circulars>(model);
        }

        public static List<Circulars> ToEntity(this List<CircularsModel> objList)
        {
            return Mapper.Map<List<CircularsModel>, List<Circulars>>(objList);
        }
    }
}