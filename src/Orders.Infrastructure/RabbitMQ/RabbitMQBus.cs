using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Orders.Application.Boundaries.PlaceOrder;
using Orders.Application.Services;
using RabbitMQ.Client;

namespace Orders.Infrastructure.RabbitMQ
{
    public class RabbitMQBus : IPublisher, IDisposable
    {
        private IConnection _connection;
        private IModel _channel;
        private IDictionary<string, Type> _binding;

        public RabbitMQBus()
        {
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
                basicProperties: null,
                body: messageBodyBytes
            );
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
    }
}