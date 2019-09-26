using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Orders.Application.Boundaries.PlaceOrder;
using Orders.Application.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Orders.Infrastructure
{
    public class RabbitMQBus : BackgroundService, IPublisher
    {
        private IConnection _connection;
        private IModel _channel;
        private IDispatcher _dispatcher;

        public RabbitMQBus(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare("orders", true, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body);
                _dispatcher.Send(ea.RoutingKey, content);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume("orders", false, consumer);
            return Task.CompletedTask;
        }

        public void PublishOrder(PlaceOrderInput placeOrderInput)
        {
            string json = JsonConvert.SerializeObject(placeOrderInput, Formatting.Indented);
            Publish("orders", json);
        }

        private void Publish(string queueName, string json)
        {
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(
                string.Empty,
                queueName,
                basicProperties : null,
                body : messageBodyBytes
            );
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}