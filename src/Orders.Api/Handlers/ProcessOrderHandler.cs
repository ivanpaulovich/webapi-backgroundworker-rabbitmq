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

        protected async override Task Handle(PlaceOrderInput request, CancellationToken cancellationToken)
        {
            await _processOrderUseCase.Execute(request);
        }
    }
}