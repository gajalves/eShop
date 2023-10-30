using Discount.Grpc.Protos;
using MediatR;

namespace eShop.Discount.Application.Queries
{
    public class GetDiscountQuery : IRequest<CouponModel>
    {
        public string Name { get; set; }

        public GetDiscountQuery(string name)
        {
            Name = name;
        }
    }
}
