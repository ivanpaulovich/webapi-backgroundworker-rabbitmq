using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.Boundaries
{
    public interface IProcessOrderUseCase
    {
         void Execute(PlaceOrderCommand placeOrderCommand);
    }
}