using System;
using Orders.Application.Boundaries.PlaceOrder;
using Orders.Application.Services;

namespace Orders.Application.UseCases
{
    public class PlaceOrder : IPlaceOrderUseCase
    {
        private readonly IPublisher _bus;

        public PlaceOrder(IPublisher bus)
        {
            _bus = bus;
        }

        public void Execute(PlaceOrderInput placeOrderInput)
        {
            Console.WriteLine($"Publishing { placeOrderInput.ToString() }");

            _bus.PublishOrder(placeOrderInput);
        }
    }
}