using eShop.Basket.Application.Responses;
using MediatR;

namespace eShop.Basket.Application.Queries
{
    public class GetBasketByUserNameQuery : IRequest<ShoppingCartResponse>
    {
        public string UserName { get; set; }


        public GetBasketByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
