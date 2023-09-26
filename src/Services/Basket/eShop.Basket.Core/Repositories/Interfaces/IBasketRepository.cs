using eShop.Basket.Core.Entities;

namespace eShop.Basket.Core.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
        Task DeleteBasket(string userName);
    }
}
