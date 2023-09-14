using eShop.Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using eShop.Catalog.Application.Responses;

namespace eShop.Catalog.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {       
        public string Id { get; set; }     
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }
    }
}
