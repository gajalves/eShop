using AutoMapper;
using eShop.Basket.Application.Responses;
using eShop.Basket.Core.Entities;

namespace eShop.Basket.Application.Mappers
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponse>().ReverseMap();
            //CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
            //CreateMap<BasketCheckoutV2, BasketCheckoutEventV2>().ReverseMap();
        }
    }
}
