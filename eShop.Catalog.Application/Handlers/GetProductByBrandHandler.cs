﻿using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Queries;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class GetProductByBrandHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _repository;

        public GetProductByBrandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProductByBrand(request.BrandName);

            var productsResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(products);

            return productsResponse;
        }
    }
}
