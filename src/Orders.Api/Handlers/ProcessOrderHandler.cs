using Orders.Api.Commands;
using Orders.Application.Boundaries;

namespace Orders.Api.Handlers
{
    public class ProcessOrderHandler : ICommandHandler<ProcessOrderCommand>
    {
        private readonly IProcessOrderUseCase _processOrderUseCase;

        public ProcessOrderHandler(IProcessOrderUseCase processOrderUseCase)
        {
            _processOrderUseCase = processOrderUseCase;
        }

        public void Handle(ProcessOrderCommand command)
        {
            _processOrderUseCase.Execute(new Application.Boundaries.PlaceOrder.PlaceOrderCommand(command);
        }
    }
}