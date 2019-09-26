using Orders.Api.Commands;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Api.Controllers
{
    public class ProcessingController
    {
        private readonly IProcessOrderUseCase _processOrderUseCase;

        public ProcessingController(IProcessOrderUseCase processOrderUseCase)
        {
            _processOrderUseCase = processOrderUseCase;
        }

        public void Execute(ProcessOrderCommand placeOrderCommand)
        {
            _processOrderUseCase.Execute(placeOrderCommand);
        }
    }
}