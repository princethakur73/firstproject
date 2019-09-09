using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class MemberExtension
    {
        public static MemberModel ToModel(this Member obj)
        {
            return Mapper.Map<Member, MemberModel>(obj);
        }

        public static List<MemberModel> ToModel(this List<Member> objList)
        {
            return Mapper.Map<List<Member>, List<MemberModel>>(objList);
        }

        public static Member ToEntity(this MemberModel model)
        {
            return Mapper.Map<MemberModel, Member>(model);
        }

        public static List<Member> ToEntity(this List<MemberModel> objList)
        {
            return Mapper.Map<List<MemberModel>, List<Member>>(objList);
        }
    }
}