using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Queries;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Repositories.Interfaces;
using eShop.Catalog.Core.Specs;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProducts(request.CatalogSpecParams);

            var productsResponde = ProductMapper.Mapper.Map<Pagination<ProductResponse>>(products);

            return productsResponde;
        }
    }
}
