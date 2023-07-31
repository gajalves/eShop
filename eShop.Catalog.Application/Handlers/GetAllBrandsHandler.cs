using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Queries;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Entities;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
    {
        private readonly IBrandRepository _repository;        

        public GetAllBrandsHandler(IBrandRepository repository)
        {
            _repository = repository;            
        }

        public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _repository.GetBrands();
            var brandResponse = ProductMapper.Mapper.Map<IList<ProductBrand>,IList<BrandResponse>>(brandList.ToList());

            return brandResponse;
        }
    }
}
