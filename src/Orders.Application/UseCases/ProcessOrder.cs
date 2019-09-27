using System;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Application.UseCases
{
    public class ProcessOrder : IProcessOrderUseCase
    {
        public void Execute(PlaceOrderInput placeOrderInput)
        {
            Console.WriteLine($"Processing { placeOrderInput.ToString() }");
        }
    }
}