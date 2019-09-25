using Orders.Application.Boundaries.ProcessOrder;
using Orders.Worker.Commands;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Worker.Controllers
{
    public class OrdersController
    {
        private readonly IProcessOrderUseCase _processOrderUseCase;

        public OrdersController(IProcessOrderUseCase processOrderUseCase)
        {
            _processOrderUseCase = processOrderUseCase;
        }

        public void Execute(PlaceOrderCommand placeOrderCommand)
        {
            _processOrderUseCase.Execute(new PlaceOrderInput(placeOrderCommand.));
        }

        public void Execute(NotHandledCommand notHandledCommand)
        {
            _processOrderUseCase.Execute(notHandledCommand);
        }
    }
}