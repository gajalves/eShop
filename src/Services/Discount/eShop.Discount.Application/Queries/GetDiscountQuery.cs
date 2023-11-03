using eShop.Discount.Application.Protos;
using MediatR;

namespace eShop.Discount.Application.Queries
{
    public class GetDiscountQuery : IRequest<CouponModel>
    {
        public string ProductName { get; set; }

        public GetDiscountQuery(string productName)
        {
            ProductName = productName;
        }
    }
}
