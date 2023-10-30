using Discount.Grpc.Protos;
using MediatR;

namespace eShop.Discount.Application.Commands
{
    public class CreateDiscountCommand : IRequest<CouponModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
