using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.Boundaries
{
    public interface IPlaceOrderUseCase
    {
         void Execute(PlaceOrderCommand placeOrderCommand);
    }
}