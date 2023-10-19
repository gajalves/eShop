using eShop.Basket.Application.Commands;
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

        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            //TODO: Call Discount service and apply coupons
            var shoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart
            {
                UserName = request.UserName,
                Items = request.Items,
            });

            return BasketMapper.Mapper.Map<ShoppingCartResponse>(shoppingCart);
        }
    }
}
