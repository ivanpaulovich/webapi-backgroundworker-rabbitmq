namespace Orders.Application.Services
{
    public interface IDispatcher
    {
        void Send(string queueName, string command);
    }
}