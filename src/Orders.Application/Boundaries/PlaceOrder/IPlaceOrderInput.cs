namespace Orders.Application.Boundaries.PlaceOrder
{
    public interface IPlaceOrderInput
    {
        int ProductId { get; }
        int Quantity { get; }
    }
}