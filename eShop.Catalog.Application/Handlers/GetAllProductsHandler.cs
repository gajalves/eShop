using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Queries;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProducts();

            var productsResponde = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);

            return productsResponde;
        }
    }
}
