namespace Orders.Application.Boundaries.PlaceOrder
{
    public interface IProcessOrderUseCase
    {
        void Execute(IPlaceOrderInput placeOrderInput);
    }
}