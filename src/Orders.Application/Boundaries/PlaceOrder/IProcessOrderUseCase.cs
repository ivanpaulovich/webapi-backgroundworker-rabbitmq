using System.Threading.Tasks;

namespace Orders.Application.Boundaries.PlaceOrder
{
    public interface IProcessOrderUseCase
    {
        Task Execute(PlaceOrderInput placeOrderInput);
    }
}