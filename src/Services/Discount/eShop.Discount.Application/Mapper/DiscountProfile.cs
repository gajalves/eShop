using AutoMapper;
using eShop.Discount.Application.Protos;
using eShop.Discount.Core.Entities;

namespace eShop.Discount.Application.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
