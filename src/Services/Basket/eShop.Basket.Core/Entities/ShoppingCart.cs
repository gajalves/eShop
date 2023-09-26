namespace eShop.Basket.Core.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public decimal TotalPrice { get; set; }

        public ShoppingCart()
        {            
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
    }
}
