using AutoMapper;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Entities;

namespace eShop.Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductBrand, BrandResponse>().ReverseMap();
        }
    }
}
