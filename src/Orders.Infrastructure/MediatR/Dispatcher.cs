using System;
using System.Collections.Generic;
using System.Text.Json;
using MediatR;
using Orders.Application.Boundaries.PlaceOrder;
using Orders.Application.Services;

namespace Orders.Infrastructure.MediatR
{
    public class Dispatcher : IDispatcher
    {
        private readonly IMediator _mediator;
        private IDictionary<string, Type> _binding;
        public Dispatcher(IMediator mediator)
        {
            _mediator = mediator;
            _binding = new Dictionary<string, Type>();
            _binding.Add(typeof(PlaceOrderInput).Name, typeof(PlaceOrderInput));
        }

        public void Send(string queueName, string json)
        {
            var messageType = _binding[queueName];
            var request = (IRequest) JsonSerializer.Deserialize(json, messageType);
            _mediator.Send(request);
        }
    }
}