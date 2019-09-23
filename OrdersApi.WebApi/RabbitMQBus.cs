using RabbitMQ.Client;

namespace OrdersApi.WebApi
{
    public class RabbitMQBus : IPublisher
    {
        public RabbitMQBus()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "userInsertMsgQ", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}