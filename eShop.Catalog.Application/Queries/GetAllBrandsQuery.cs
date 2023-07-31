using eShop.Catalog.Application.Responses;
using MediatR;

namespace eShop.Catalog.Application.Queries
{
    public class GetAllBrandsQuery : IRequest<IList<BrandResponse>>
    {
    }
}
