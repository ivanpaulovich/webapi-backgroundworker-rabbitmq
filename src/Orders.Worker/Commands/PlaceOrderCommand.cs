using Orders.Worker.Controllers;

namespace Orders.Worker.Commands
{
    public class PlaceOrderCommand : ICommand
    {
        public void Execute(OrdersController ordersController)
        {
            ordersController.Execute(this);
        }

        public bool Match(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}