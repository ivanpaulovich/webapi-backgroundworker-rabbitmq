using System;
using System.Threading.Tasks;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.UseCases
{
    public class ProcessOrder : IProcessOrderUseCase
    {
        public Task Execute(PlaceOrderInput placeOrderInput)
        {
            Console.WriteLine($"Processing { placeOrderInput.ToString() }");
            return Task.CompletedTask;
        }
    }
}