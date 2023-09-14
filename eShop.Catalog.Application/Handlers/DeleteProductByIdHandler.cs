using eShop.Catalog.Application.Queries;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdQuery, bool>
    {
        private readonly IProductRepository _repository;

        public DeleteProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteProductByIdQuery request, CancellationToken cancellationToken)
        {            
            return await _repository.DeleteProduct(request.Id);
        }
    }
}
