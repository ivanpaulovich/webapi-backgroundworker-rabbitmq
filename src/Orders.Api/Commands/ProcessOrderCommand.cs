using Orders.Api.Controllers;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Api.Commands
{
    public class ProcessOrderCommand : ICommand, IPlaceOrderInput
    {
        public int ProductId { get; }
        public int Quantity { get; }

        public void Execute(ProcessingController controller)
        {
            controller.Execute(this);
        }

        public bool Match(string queueName)
        {
            return queueName == "orders";
        }
    }
}