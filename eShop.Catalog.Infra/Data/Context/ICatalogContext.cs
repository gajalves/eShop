using eShop.Catalog.Core.Entities;
using MongoDB.Driver;

namespace eShop.Catalog.Infra.Data.Context
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<ProductBrand> Brands { get; }
        IMongoCollection<ProductType> Types { get; }
    }
}
