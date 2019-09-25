using Orders.Application.Boundaries;

namespace Orders.Application.Services
{
    public interface IPublisher
    {
         void Publish<T>(T message);
    }
}