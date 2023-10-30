using MediatR;

namespace eShop.Discount.Application.Commands
{
    public class DeleteDiscountCommand : IRequest<bool>
{
    public string Name { get; set; }

    public DeleteDiscountCommand(string name)
    {
        Name = name;
    }
}
}
