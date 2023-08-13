using eShop.Catalog.Application.Responses;
using MediatR;

namespace eShop.Catalog.Application.Queries
{
    public class GetAllTypesQuery : IRequest<IList<TypesResponse>>
    {

    }
}
