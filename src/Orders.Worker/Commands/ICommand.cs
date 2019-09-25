using Orders.Worker.Controllers;

namespace Orders.Worker.Commands
{
    public interface ICommand
    {
        bool Match(string[] args);
        void Execute(OrdersController ordersController);
    }
}