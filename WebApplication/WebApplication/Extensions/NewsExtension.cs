using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class NewsExtension
    {
        public static NewsModel ToModel(this News obj)
        {
            return Mapper.Map<News, NewsModel>(obj);
        }

        public static List<NewsModel> ToModel(this List<News> objList)
        {
            return Mapper.Map<List<News>, List<NewsModel>>(objList);
        }

        public static News ToEntity(this NewsModel model)
        {
            return Mapper.Map<NewsModel, News>(model);
        }

        public static List<News> ToEntity(this List<NewsModel> objList)
        {
            return Mapper.Map<List<NewsModel>, List<News>>(objList);
        }
    }
}