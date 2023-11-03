using eShop.Discount.Application.Protos;
using MediatR;

namespace eShop.Discount.Application.Commands
{
    public class CreateDiscountCommand : IRequest<CouponModel>
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
