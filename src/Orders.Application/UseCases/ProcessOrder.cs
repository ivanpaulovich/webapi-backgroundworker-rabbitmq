using Orders.Application.Boundaries;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.UseCases
{
    public class ProcessOrder : IProcessOrderUseCase
    {
        public void Execute(PlaceOrderCommand placeOrderCommand)
        {
            throw new System.NotImplementedException();
        }
    }
}