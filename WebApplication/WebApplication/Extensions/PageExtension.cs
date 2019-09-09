using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication
{
    public static class PageExtension
    {
        public static PageModel ToModel(this Page obj)
        {
            return Mapper.Map<Page, PageModel>(obj);
        }

        public static List<PageModel> ToModel(this List<Page> objList)
        {
            return Mapper.Map<List<Page>, List<PageModel>>(objList);
        }

        public static Page ToEntity(this PageModel model)
        {
            return Mapper.Map<PageModel, Page>(model);
        }

        public static List<Page> ToEntity(this List<PageModel> objList)
        {
            return Mapper.Map<List<PageModel>, List<Page>>(objList);
        }
    }
}