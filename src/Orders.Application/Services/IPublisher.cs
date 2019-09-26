using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.Services
{
    public interface IPublisher
    {
        void PublishOrder(PlaceOrderInput placeOrderInput);
    }
}