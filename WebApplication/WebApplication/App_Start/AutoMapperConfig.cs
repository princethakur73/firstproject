using AutoMapper;
using WebApplication.Area.Admin.Models;
using WebApplication.Core;
using WebApplication.Core.Common;
using WebApplication.Models;

namespace WebApplication
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(config =>
            {

                config.CreateMap<Page, PageModel>().ReverseMap();
                config.CreateMap<Gallery, GalleryModel>().ReverseMap();
                config.CreateMap<Member, MemberModel>().ReverseMap();
                config.CreateMap<StaffDetail, StaffDetailModel>().ReverseMap();
                config.CreateMap<Toppers, ToppersModel>().ReverseMap();
                config.CreateMap<ClassMaster, ClassModel>().ReverseMap();
                config.CreateMap<Slide, SlideModel>().ReverseMap();
                config.CreateMap<ContactUs, ContactUsModel>().ReverseMap();
                config.CreateMap<News, NewsModel>().ReverseMap();
                config.CreateMap<Downloads, DownloadsModel>().ReverseMap();
                config.CreateMap<TransferCerticate, TransferCertificateModel>().ReverseMap();
                config.CreateMap<DepartmentMaster, DepartmentModel>().ReverseMap();
                config.CreateMap<Circulars, CircularsModel>().ReverseMap();
                config.CreateMap<DepartmentMaster, DepartmentModel>().ReverseMap();
                config.CreateMap<StudentAdmission, StudentAdmissionModel>().ReverseMap();
            });
        }
    }
}