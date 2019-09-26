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

        [HttpGet]
        public IActionResult Get()
        {
            _placeOrderUseCase.Execute(new PlaceOrderInput(42, 3));
            return Ok();
        }
    }
}