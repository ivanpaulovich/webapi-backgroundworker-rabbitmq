using Orders.Application.Boundaries.PlaceOrder;
using Orders.Application.Boundaries.ProcessOrder;

namespace Orders.Api.Controllers
{
    public class OrdersController
    {
        private readonly IProcessOrderUseCase _processOrderUseCase;

        public OrdersController(IProcessOrderUseCase processOrderUseCase)
        {
            _processOrderUseCase = processOrderUseCase;
        }

        public void Execute(PlaceOrderInput placeOrderInput)
        {
            _processOrderUseCase.Execute(placeOrderInput);
        }
    }
}