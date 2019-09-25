namespace Orders.Application.Boundaries.PlaceOrder
{
    public class PlaceOrderCommand
    {
        public int ProductId { get; }
        public int Quantity { get; }

        public PlaceOrderCommand(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}