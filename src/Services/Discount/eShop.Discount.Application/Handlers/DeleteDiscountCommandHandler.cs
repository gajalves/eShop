using eShop.Discount.Application.Commands;
using eShop.Discount.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Discount.Application.Handlers
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, bool>
    {
        private readonly IDiscountRepository _repository;

        public DeleteDiscountCommandHandler(IDiscountRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _repository.DeleteDiscount(request.Name);
            return deleted;
        }
    }
}
