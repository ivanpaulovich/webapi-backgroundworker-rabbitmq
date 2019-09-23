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
            _channel.ExchangeDeclare("exchangeName", ExchangeType.Direct);
            _channel.QueueDeclare("queueName", false, false, false, null);
            _channel.QueueBind("queueName", "exchangeName", "routingKey", null);
        }

        public void Publish(string message)
        {
            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish("exchangeName", "routingKey", null, messageBodyBytes);
        }
    }
}