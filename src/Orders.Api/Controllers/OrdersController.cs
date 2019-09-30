using System;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Boundaries.PlaceOrder;

namespace OrdersApi.Api.Controllers
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

        [HttpPost]
        public IActionResult Post([FromForm]int productId, [FromForm]int quantity)
        {
            _placeOrderUseCase.Execute(new PlaceOrderInput(productId, quantity, DateTime.Now));
            return Ok();
        }
    }
}