using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Orders.Application.Boundaries;
using Orders.Application.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Orders.Api
{
    public class ConsumeRabbitMQHostedService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IDispatcher _dispatcher;

        public ConsumeRabbitMQHostedService()
        {
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare("Q1", true, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = System.Text.Encoding.UTF8.GetString(ea.Body);
                HandleMessage(content);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume("Q1", false, consumer);
            return Task.CompletedTask;
        }

        private void HandleMessage(string content)
        {
            var command = JsonConvert.DeserializeObject<ICommand>(content);
            _dispatcher.Send(command);;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}