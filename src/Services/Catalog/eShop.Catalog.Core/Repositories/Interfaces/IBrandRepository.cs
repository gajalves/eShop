using eShop.Catalog.Core.Entities;

namespace eShop.Catalog.Core.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ProductBrand>> GetBrands();
    }
}
