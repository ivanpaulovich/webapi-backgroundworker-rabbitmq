using Newtonsoft.Json;
using Orders.Application.Services;
using RabbitMQ.Client;

namespace OrdersApi.WebApi
{
    public class RabbitMQBus : IPublisher
    {
        private readonly IModel _channel;

        public RabbitMQBus()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            var connection = factory.CreateConnection();

            _channel = connection.CreateModel();
            _channel.QueueDeclare("Q1", true, false, false, null);
        }

        public void Publish<T>(T message)
        {
            string data = JsonConvert.SerializeObject(message, Formatting.Indented);
            
            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(data);
            _channel.BasicPublish(string.Empty,
                    "Q1", basicProperties: null,
                    body: messageBodyBytes);
        }
    }
}