using AutoMapper;
using Northwind.Models;
using Northwind.ViewModels;

namespace Northwind.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductList_VM>().ReverseMap();
        }
    }
}
