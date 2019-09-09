using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class ContactUsExtension
    {
        public static ContactUsModel ToModel(this ContactUs obj)
        {
            return Mapper.Map<ContactUs, ContactUsModel>(obj);
        }

        public static List<ContactUsModel> ToModel(this List<ContactUs> objList)
        {
            return Mapper.Map<List<ContactUs>, List<ContactUsModel>>(objList);
        }

        public static ContactUs ToEntity(this ContactUsModel model)
        {
            return Mapper.Map<ContactUsModel, ContactUs>(model);
        }

        public static List<ContactUs> ToEntity(this List<ContactUsModel> objList)
        {
            return Mapper.Map<List<ContactUsModel>, List<ContactUs>>(objList);
        }
    }
}