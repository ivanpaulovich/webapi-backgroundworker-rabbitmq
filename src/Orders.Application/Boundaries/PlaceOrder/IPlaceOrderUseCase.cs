namespace Orders.Application.Boundaries.PlaceOrder
{
    public interface IPlaceOrderUseCase
    {
         void Execute(PlaceOrderInput placeOrderInput);
    }
}