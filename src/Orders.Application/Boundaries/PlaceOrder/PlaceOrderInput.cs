using MediatR;

namespace Orders.Application.Boundaries.PlaceOrder
{
    public class PlaceOrderInput : IRequest
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