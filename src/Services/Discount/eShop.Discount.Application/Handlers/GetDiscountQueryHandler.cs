using eShop.Discount.Application.Protos;
using eShop.Discount.Application.Queries;
using eShop.Discount.Core.Repositories;
using Grpc.Core;
using MediatR;

namespace eShop.Discount.Application.Handlers
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository;

        public GetDiscountQueryHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _discountRepository.GetDiscount(request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"Discount with the product name = {request.ProductName} not found"));
            }
            //TODO: Exercise Follow Product Mapper kind of example
            var couponModel = new CouponModel
            {
                Id = coupon.Id,
                Amount = coupon.Amount,
                Description = coupon.Description,
                ProductName = coupon.ProductName
            };
            return couponModel;
        }
    }
}
