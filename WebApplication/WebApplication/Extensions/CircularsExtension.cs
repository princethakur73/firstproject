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

        public static PtmModel ToModel(this Ptm obj)
        {
            return Mapper.Map<Ptm, PtmModel>(obj);
        }
        public static List<PtmModel> ToModel(this List<Ptm> objList)
        {
            return Mapper.Map<List<Ptm>, List<PtmModel>>(objList);
        }
        public static Ptm ToEntity(this PtmModel model)
        {
            return Mapper.Map<PtmModel, Ptm>(model);
        }

        public static List<Ptm> ToEntity(this List<PtmModel> objList)
        {
            return Mapper.Map<List<PtmModel>, List<Ptm>>(objList);
        }


    }
}