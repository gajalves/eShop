using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Specs;
using MediatR;

namespace eShop.Catalog.Application.Queries
{
    public class GetAllProductsQuery : IRequest<Pagination<ProductResponse>>
    {
        public CatalogSpecParams CatalogSpecParams { get; set; }

        public GetAllProductsQuery(CatalogSpecParams catalogSpecParams)
        {
            CatalogSpecParams = catalogSpecParams;
        }
    }
}
