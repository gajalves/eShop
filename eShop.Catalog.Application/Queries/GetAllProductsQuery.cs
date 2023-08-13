using eShop.Catalog.Application.Responses;
using MediatR;

namespace eShop.Catalog.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IList<ProductResponse>>
    {
    }
}
