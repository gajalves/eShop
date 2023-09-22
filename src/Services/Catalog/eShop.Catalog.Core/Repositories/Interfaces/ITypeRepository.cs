using eShop.Catalog.Core.Entities;

namespace eShop.Catalog.Core.Repositories.Interfaces
{
    public interface ITypeRepository
    {
        Task<IEnumerable<ProductType>> GetTypes();
    }
}
