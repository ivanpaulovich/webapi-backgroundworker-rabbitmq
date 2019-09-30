using System;
using MediatR;

namespace Orders.Application.Boundaries.PlaceOrder
{
    public class PlaceOrderInput : IRequest
    {
        public int ProductId { get; }
        public int Quantity { get; }
        public DateTime Timestamp { get; set; }

        public PlaceOrderInput(int productId, int quantity, DateTime timestamp)
        {
            ProductId = productId;
            Quantity = quantity;
            Timestamp = timestamp;
        }
    }
}