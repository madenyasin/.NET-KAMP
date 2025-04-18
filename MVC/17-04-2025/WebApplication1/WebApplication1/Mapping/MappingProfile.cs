using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kitap, KitapEkleViewModel>().ReverseMap();
            CreateMap<Kitap, KitapGuncelleViewModel>().ReverseMap();
            CreateMap<Kitap, KitapDetayViewModel>()
             .ForMember(x => x.KategoriAdi, opt => opt.MapFrom(src => src.Kategori.Ad))
             .ForMember(x => x.YazarAdi, opt => opt.MapFrom(src => src.Yazar.Ad))
             .ForMember(x => x.YayinEviAdi, opt => opt.MapFrom(src => src.YayinEvi.Ad));

        }
    }
}
