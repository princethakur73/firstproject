using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class DatesheetExtension
    {
        public static DatesheetModel ToModel(this Datesheet obj)
        {
            return Mapper.Map<Datesheet, DatesheetModel>(obj);
        }

        public static List<DatesheetModel> ToModel(this List<Datesheet> objList)
        {
            return Mapper.Map<List<Datesheet>, List<DatesheetModel>>(objList);
        }

        public static Datesheet ToEntity(this DatesheetModel model)
        {
            return Mapper.Map<DatesheetModel, Datesheet>(model);
        }

        public static List<Datesheet> ToEntity(this List<DatesheetModel> objList)
        {
            return Mapper.Map<List<DatesheetModel>, List<Datesheet>>(objList);
        }
    }
}