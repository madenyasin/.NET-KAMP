using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Uye, LoginViewModel>().ReverseMap();

            CreateMap<RegisterViewModel, Uye>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.KullaniciAdi))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EPosta))
               .ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.Ad))
               .ForMember(dest => dest.Soyad, opt => opt.MapFrom(src => src.Soyad))
               .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()).ReverseMap();

            CreateMap<Not, NotGuncelleViewModel>().ReverseMap();
        }
    }
}
