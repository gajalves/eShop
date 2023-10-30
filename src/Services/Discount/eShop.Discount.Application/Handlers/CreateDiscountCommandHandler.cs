using AutoMapper;
using Discount.Grpc.Protos;
using eShop.Discount.Application.Commands;
using eShop.Discount.Core.Entities;
using eShop.Discount.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Discount.Application.Handlers
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, CouponModel>
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public CreateDiscountCommandHandler(IDiscountRepository repository,
                                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(request);
            await _repository.CreateDiscount(coupon);
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
    }
}
