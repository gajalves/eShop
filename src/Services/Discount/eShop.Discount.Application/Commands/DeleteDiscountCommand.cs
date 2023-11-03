using MediatR;

namespace eShop.Discount.Application.Commands
{
    public class DeleteDiscountCommand : IRequest<bool>
    {
        public string ProductName { get; set; }

        public DeleteDiscountCommand(string productName)
        {
            ProductName = productName;
        }
    }
}