using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Queries;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetProductByNameHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProductByName(request.Name);

            var productsResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);

            return productsResponse;
        }
    }
}
