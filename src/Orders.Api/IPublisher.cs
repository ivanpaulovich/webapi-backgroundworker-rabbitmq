namespace OrdersApi.WebApi
{
    public interface IPublisher
    {
         void Publish(string message);
    }
}