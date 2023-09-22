using MediatR;

namespace eShop.Catalog.Application.Queries
{
    public class DeleteProductByIdQuery : IRequest<bool>
    {
        public string Id { get; }

        public DeleteProductByIdQuery(string id)
        {
            Id = id;
        }
    }
}
