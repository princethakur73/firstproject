using AutoMapper;
using System.Collections.Generic;
using WebApplication.Core;
using WebApplication.Models;

namespace WebApplication
{
    public static class TransferCertificateExtension
    {
        public static TransferCertificateModel ToModel(this TransferCerticate obj)
        {
            return Mapper.Map<TransferCerticate, TransferCertificateModel>(obj);
        }

        public static List<TransferCertificateModel> ToModel(this List<TransferCerticate> objList)
        {
            return Mapper.Map<List<TransferCerticate>, List<TransferCertificateModel>>(objList);
        }

        public static TransferCerticate ToEntity(this TransferCertificateModel model)
        {
            return Mapper.Map<TransferCertificateModel, TransferCerticate>(model);
        }

        public static List<TransferCerticate> ToEntity(this List<TransferCertificateModel> objList)
        {
            return Mapper.Map<List<TransferCertificateModel>, List<TransferCerticate>>(objList);
        }
    }
}