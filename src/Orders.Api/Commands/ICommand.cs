using Orders.Api.Controllers;

namespace Orders.Api.Commands
{
    public interface ICommand
    {
        bool Match(string queueName);
        void Execute(ProcessingController controller);
    }
}