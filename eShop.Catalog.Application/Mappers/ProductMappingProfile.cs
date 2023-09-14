using AutoMapper;
using eShop.Catalog.Application.Commands;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Entities;

namespace eShop.Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<ProductBrand, BrandResponse>().ReverseMap();
            CreateMap<ProductType, TypesResponse>().ReverseMap();
        }
    }
}
