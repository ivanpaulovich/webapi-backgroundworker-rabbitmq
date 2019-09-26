namespace Orders.Application.Boundaries.PlaceOrder
{
    public class PlaceOrderInput : IPlaceOrderInput
    {
        public int ProductId { get; }
        public int Quantity { get; }

        public PlaceOrderInput(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}