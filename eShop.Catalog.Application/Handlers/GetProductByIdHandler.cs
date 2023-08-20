using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Queries;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProduct(request.Id);

            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(product);

            return productResponse;
        }
    }
}
