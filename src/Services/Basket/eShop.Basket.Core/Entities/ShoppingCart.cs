namespace eShop.Basket.Core.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public decimal TotalPrice { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new();

        public ShoppingCart()
        {            
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public ShoppingCart(string userName, List<ShoppingCartItem> items)
        {
            UserName = userName;
            Items = items;
        }
    }
}
