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
        public static DepartmentModel ToModel(this DepartmentMaster obj)
        {
            return Mapper.Map<DepartmentMaster, DepartmentModel>(obj);
        }

        public static List<ClassModel> ToModel(this List<ClassMaster> objList)
        {
            return Mapper.Map<List<ClassMaster>, List<ClassModel>>(objList);
        }
        public static List<DepartmentModel> ToModel(this List<DepartmentMaster> objList)
        {
            return Mapper.Map<List<DepartmentMaster>, List<DepartmentModel>>(objList);
        }

        public static ClassMaster ToEntity(this ClassModel model)
        {
            return Mapper.Map<ClassModel, ClassMaster>(model);
        }
        public static DepartmentMaster ToEntity(this DepartmentModel model)
        {
            return Mapper.Map<DepartmentModel, DepartmentMaster>(model);
        }

        public static List<ClassMaster> ToEntity(this List<ClassModel> objList)
        {
            return Mapper.Map<List<ClassModel>, List<ClassMaster>>(objList);
        }
        public static List<DepartmentMaster> ToEntity(this List<DepartmentModel> objList)
        {
            return Mapper.Map<List<DepartmentModel>, List<DepartmentMaster>>(objList);
        }
    }
}