using Discount.Grpc.Protos;
using eShop.Discount.Application.Queries;
using eShop.Discount.Core.Repositories.Interfaces;
using Grpc.Core;
using MediatR;

namespace eShop.Discount.Application.Handlers
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
    {
        private IDiscountRepository _repository;

        public GetDiscountQueryHandler(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _repository.GetDiscount(request.Name);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"Discount with the product name = {request.Name} not found"));
            }
            //TODO: Exercise Follow Product Mapper kind of example
            var couponModel = new CouponModel
            {
                Id = coupon.Id,
                Amount = coupon.Amount,
                Description = coupon.Description,
                Name = coupon.Name
            };
            return couponModel;
        }
    }
}
