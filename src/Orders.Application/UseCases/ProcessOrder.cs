using System;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.UseCases
{
    public class ProcessOrder : IProcessOrderUseCase
    {
        public void Execute(IPlaceOrderInput placeOrderInput)
        {
            Console.WriteLine($"Processing { placeOrderInput.ToString() }");
        }
    }
}