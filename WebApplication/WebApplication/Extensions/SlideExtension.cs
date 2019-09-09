using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class SlideExtension
    {
        public static SlideModel ToModel(this Slide obj)
        {
            return Mapper.Map<Slide, SlideModel>(obj);
        }

        public static List<SlideModel> ToModel(this List<Slide> objList)
        {
            return Mapper.Map<List<Slide>, List<SlideModel>>(objList);
        }

        public static Slide ToEntity(this SlideModel model)
        {
            return Mapper.Map<SlideModel, Slide>(model);
        }

        public static List<Slide> ToEntity(this List<SlideModel> objList)
        {
            return Mapper.Map<List<SlideModel>, List<Slide>>(objList);
        }
    }
}