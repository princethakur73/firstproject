using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class StaffDetailExtension
    {
        public static StaffDetailModel ToModel(this StaffDetail obj)
        {
            return Mapper.Map<StaffDetail, StaffDetailModel>(obj);
        }

        public static List<StaffDetailModel> ToModel(this List<StaffDetail> objList)
        {
            return Mapper.Map<List<StaffDetail>, List<StaffDetailModel>>(objList);
        }

        public static StaffDetail ToEntity(this StaffDetailModel model)
        {
            return Mapper.Map<StaffDetailModel, StaffDetail>(model);
        }

        public static List<StaffDetail> ToEntity(this List<StaffDetailModel> objList)
        {
            return Mapper.Map<List<StaffDetailModel>, List<StaffDetail>>(objList);
        }
    }
}