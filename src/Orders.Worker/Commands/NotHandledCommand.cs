using Orders.Worker.Controllers;

namespace Orders.Worker.Commands
{
    public class NotHandledCommand : ICommand
    {
        public void Execute(OrdersController ordersController)
        {
            throw new System.NotImplementedException();
        }

        public bool Match(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}