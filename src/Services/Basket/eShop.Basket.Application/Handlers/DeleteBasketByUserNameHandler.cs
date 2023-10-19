using eShop.Basket.Application.Queries;
using eShop.Basket.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Basket.Application.Handlers
{
    public class DeleteBasketByUserNameHandler : IRequestHandler<DeleteBasketByUserNameQuery, Unit>
    {
        private readonly IBasketRepository _repository;

        public DeleteBasketByUserNameHandler(IBasketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            await _repository.DeleteBasket(request.UserName);
            return Unit.Value;
        }        
    }
}
