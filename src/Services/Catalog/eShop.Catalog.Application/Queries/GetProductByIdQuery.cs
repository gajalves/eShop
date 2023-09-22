using eShop.Catalog.Application.Responses;
using MediatR;

namespace eShop.Catalog.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public string Id { get; set; }

        public GetProductByIdQuery(string id)
        {
            Id = id;
        }

    }
}
