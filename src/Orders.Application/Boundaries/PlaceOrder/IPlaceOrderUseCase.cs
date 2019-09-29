using System.Threading.Tasks;

namespace Orders.Application.Boundaries.PlaceOrder
{
    public interface IPlaceOrderUseCase
    {
        Task Execute(PlaceOrderInput placeOrderInput);
    }
}