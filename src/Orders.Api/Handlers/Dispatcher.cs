using System;
using System.Collections.Generic;
using Orders.Application.Boundaries;
using Orders.Application.Boundaries.PlaceOrder;
using Orders.Application.Services;

namespace Orders.Api.Handlers
{
    public class Dispatcher : IDispatcher
    {
        private readonly IDictionary<Type, IUseCase<ICommand>> _handlers;
        public Dispatcher(IUseCase<PlaceOrderCommand> placeOrderUseCase)
        {
            _handlers = new Dictionary<Type, IUseCase<ICommand>>();
            _handlers.Add(typeof(PlaceOrderCommand), placeOrderUseCase);
        }

        public void Send(ICommand command)
        {
            _handlers[command.GetType()].Execute(command);
        }
    }
}