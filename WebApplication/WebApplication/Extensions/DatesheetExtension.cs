using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class DatesheetExtension
    {
        public static FileTypeModel ToModel(this File obj)
        {
            return Mapper.Map<File, FileTypeModel>(obj);
        }

        public static List<FileTypeModel> ToModel(this List<File> objList)
        {
            return Mapper.Map<List<File>, List<FileTypeModel>>(objList);
        }

        public static File ToEntity(this FileTypeModel model)
        {
            return Mapper.Map<FileTypeModel, File>(model);
        }

        public static List<File> ToEntity(this List<FileTypeModel> objList)
        {
            return Mapper.Map<List<FileTypeModel>, List<File>>(objList);
        }
    }
}