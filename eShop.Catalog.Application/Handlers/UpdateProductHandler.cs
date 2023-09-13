using eShop.Catalog.Application.Commands;
using eShop.Catalog.Core.Entities;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.UpdateProduct(new Product
            {
                Id = request.Id,
                Name = request.Name,
                ImageFile = request.ImageFile,
                Description = request.Description,
                Price = request.Price,
                Brands = request.Brands,
                Types = request.Types,
            });

            return product;
        }
    }
}
