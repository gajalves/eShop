using eShop.Catalog.Core.Entities;
using eShop.Catalog.Core.Specs;

namespace eShop.Catalog.Core.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByBrand(string name);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);

    }
}
