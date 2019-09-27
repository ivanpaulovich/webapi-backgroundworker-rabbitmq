using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Api.Handlers
{
    public class ProcessOrderHandler : AsyncRequestHandler<PlaceOrderInput>
    {
        private readonly IProcessOrderUseCase _processOrderUseCase;

        public ProcessOrderHandler(IProcessOrderUseCase processOrderUseCase)
        {
            _processOrderUseCase = processOrderUseCase;
        }

        protected override Task Handle(PlaceOrderInput request, CancellationToken cancellationToken)
        {
            _processOrderUseCase.Execute(request);
            return Task.CompletedTask;
        }
    }
}