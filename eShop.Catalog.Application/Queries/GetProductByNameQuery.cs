using eShop.Catalog.Application.Responses;
using MediatR;

namespace eShop.Catalog.Application.Queries
{
    public class GetProductByNameQuery : IRequest<IList<ProductResponse>>
    {
        public string Name { get; set; }

        public GetProductByNameQuery(string name)
        {
            Name = name;
        }
    }
}
