using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class AdmissionExtension
    {
        public static StudentAdmissionModel ToModel(this StudentAdmission obj)
        {
            return Mapper.Map<StudentAdmission, StudentAdmissionModel>(obj);
        }

        public static List<StudentAdmissionModel> ToModel(this List<StudentAdmission> objList)
        {
            return Mapper.Map<List<StudentAdmission>, List<StudentAdmissionModel>>(objList);
        }

        public static StudentAdmission ToEntity(this StudentAdmissionModel model)
        {
            return Mapper.Map<StudentAdmissionModel, StudentAdmission>(model);
        }

        public static List<StudentAdmission> ToEntity(this List<StudentAdmissionModel> objList)
        {
            return Mapper.Map<List<StudentAdmissionModel>, List<StudentAdmission>>(objList);
        }
    }
}