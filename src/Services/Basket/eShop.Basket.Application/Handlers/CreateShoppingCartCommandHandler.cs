using eShop.Basket.Application.Commands;
using eShop.Basket.Application.GrpcService;
using eShop.Basket.Application.Mappers;
using eShop.Basket.Application.Responses;
using eShop.Basket.Core.Entities;
using eShop.Basket.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Basket.Application.Handlers
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;

        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository,
                                                DiscountGrpcService discountGrpcService)
        {
            _basketRepository = basketRepository;
            _discountGrpcService = discountGrpcService;
        }

        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }

            var shoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart
            {
                UserName = request.UserName,
                Items = request.Items,
            });

            return BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
        }
    }
}
