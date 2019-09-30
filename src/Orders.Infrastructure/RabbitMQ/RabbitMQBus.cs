using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Orders.Application.Boundaries.PlaceOrder;
using Orders.Application.Services;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Orders.Infrastructure.RabbitMQ
{
    public class RabbitMQBus : BackgroundService, IPublisher
    {
        private IConnection _connection;
        private IModel _channel;
        private IMediator _mediator;
        private IDictionary<string, Type> _binding;

        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _binding = new Dictionary<string, Type>();
            _binding.Add(typeof(PlaceOrderInput).Name, typeof(PlaceOrderInput));

            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(typeof(PlaceOrderInput).Name, true, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += OnReceived;

            _channel.BasicConsume(typeof(PlaceOrderInput).Name, false, consumer);
            return Task.CompletedTask;
        }

        private void OnReceived(object ch, BasicDeliverEventArgs ea)
        {
            var policy = Policy.Handle<Exception>()
                .RetryAsync(3);

            policy.ExecuteAsync(async () => await Send(ea.RoutingKey, ea.Body, ea.DeliveryTag))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
        
        private async Task Send(string key, byte[] body, ulong deliveryTag)
        {
            var messageType = _binding[key];
            var content = Encoding.UTF8.GetString(body);

            var request = (IRequest) JsonConvert.DeserializeObject(content, messageType);
            await _mediator.Send(request);

            _channel.BasicAck(deliveryTag, false);
        }

        public void PublishOrder(PlaceOrderInput placeOrderInput)
        {
            string json = JsonConvert.SerializeObject(placeOrderInput);

            Publish(typeof(PlaceOrderInput).Name, json);
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