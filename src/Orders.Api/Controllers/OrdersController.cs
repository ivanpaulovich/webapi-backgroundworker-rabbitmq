using System;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Boundaries.PlaceOrder;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IPlaceOrderUseCase _placeOrderUseCase;

        public OrdersController(IPlaceOrderUseCase placeOrderUseCase)
        {
            _placeOrderUseCase = placeOrderUseCase;
        }

        [HttpGet]
        public IActionResult Get([FromForm]int productId, [FromForm]int quantity)
        {
            _placeOrderUseCase.Execute(new PlaceOrderInput(productId, quantity, DateTime.Now));
            return Ok();
        }
    }
}