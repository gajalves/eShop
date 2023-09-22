using eShop.Catalog.Application.Commands;
using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Entities;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<Product>(request);

            if (productEntity is null)
                throw new ApplicationException("Issue whit mapping while creating new product");
            
            var product = await _repository.CreateProduct(productEntity);

            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(product);

            return productResponse;
        }
    }
}
