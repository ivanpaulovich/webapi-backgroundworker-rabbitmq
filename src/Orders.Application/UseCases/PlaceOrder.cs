using System;
using System.Threading.Tasks;
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

        public Task Execute(PlaceOrderInput placeOrderInput)
        {
            _bus.PublishOrder(placeOrderInput);

            return Task.CompletedTask;
        }
    }
}