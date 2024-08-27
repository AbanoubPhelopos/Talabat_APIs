using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;

namespace Talabat.APIs.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>().ForMember(d => d.Brand, O => O.MapFrom(s => s.Brand))
            .ForMember(d => d.Category, O => O.MapFrom(s => s.Category))
            .ForMember(d=>d.PictureUrl,O=>O.MapFrom<ProductPictureUrlResolver>());
    }
}