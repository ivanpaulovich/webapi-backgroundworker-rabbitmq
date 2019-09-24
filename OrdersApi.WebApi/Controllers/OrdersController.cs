using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrdersApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IPublisher _publisher;

        public OrdersController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string d = DateTime.Now.ToString();
            _publisher.Publish(d);
            return Ok(d);
        }
    }
}
