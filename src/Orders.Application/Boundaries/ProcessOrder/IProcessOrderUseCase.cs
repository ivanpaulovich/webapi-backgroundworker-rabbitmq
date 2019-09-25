using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.Boundaries.ProcessOrder
{
    public interface IProcessOrderUseCase
    {
         void Execute(PlaceOrderInput placeOrderInput);
    }
}