using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDTO>()
                .ForMember(brand => brand.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(type => type.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(pic => pic.PicUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}