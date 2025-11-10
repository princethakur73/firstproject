using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class SlideExtension
    {
        private static readonly Dictionary<int, string> SlideTypeNames = new Dictionary<int, string>
        {
            { 1, "Home" },
            { 2, "Kindergarten" } 
            // Add more mappings as needed
        };
        public static SlideModel ToModel(this Slide obj)
        {
            var model = Mapper.Map<Slide, SlideModel>(obj);
            model.TypeName = SlideTypeNames.TryGetValue(obj.Type, out var name) ? name : "Unknown";
            return model;
            //return Mapper.Map<Slide, SlideModel>(obj);
        }

        public static List<SlideModel> ToModel(this List<Slide> objList)
        {
            return objList.Select(s => s.ToModel()).ToList();
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