using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels.Kitap;
using WebApplication1.ViewModels.Login;

namespace WebApplication1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Register_VM, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.KullaniciAdi))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Eposta))
                .ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.Ad))
                .ForMember(dest => dest.Soyad, opt => opt.MapFrom(src => src.Soyad))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()).ReverseMap();


            CreateMap<Kitap, KitapListele_VM>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();
        }
    }
}
