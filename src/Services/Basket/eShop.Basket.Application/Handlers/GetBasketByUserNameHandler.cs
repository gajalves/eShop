using eShop.Basket.Application.Mappers;
using eShop.Basket.Application.Queries;
using eShop.Basket.Application.Responses;
using eShop.Basket.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Basket.Application.Handlers
{
    public class GetBasketByUserNameHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
    {
        private readonly IBasketRepository _repository;

        public GetBasketByUserNameHandler(IBasketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var basket = await _repository.GetBasket(request.UserName);

            return BasketMapper.Mapper.Map<ShoppingCartResponse>(basket);
        }
    }
}
