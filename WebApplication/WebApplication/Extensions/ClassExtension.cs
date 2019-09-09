using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class ClassExtension
    {
        public static ClassModel ToModel(this ClassMaster obj)
        {
            return Mapper.Map<ClassMaster, ClassModel>(obj);
        }

        public static List<ClassModel> ToModel(this List<ClassMaster> objList)
        {
            return Mapper.Map<List<ClassMaster>, List<ClassModel>>(objList);
        }

        public static ClassMaster ToEntity(this ClassModel model)
        {
            return Mapper.Map<ClassModel, ClassMaster>(model);
        }

        public static List<ClassMaster> ToEntity(this List<ClassModel> objList)
        {
            return Mapper.Map<List<ClassModel>, List<ClassMaster>>(objList);
        }
    }
}