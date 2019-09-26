using Newtonsoft.Json;
using Orders.Api.Controllers;
using Orders.Application.Services;

namespace Orders.Api.Commands
{
    public class Dispatcher : IDispatcher
    {
        private readonly ProcessingController _processingController;
        public Dispatcher(ProcessingController processingController)
        {
            _processingController = processingController;
        }

        public void Send(string queueName, string json)
        {
            ICommand command = null;
            if (queueName == "orders")
                command = JsonConvert.DeserializeObject<ProcessOrderCommand>(json);
            if (command != null)
                command.Execute(_processingController);
        }
    }
}