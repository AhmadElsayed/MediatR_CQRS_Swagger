using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatR_CQRS_Swagger.Orders.Commands;
using MediatR_CQRS_Swagger.Queries;
using MediatR_CQRS_Swagger.Queries.GetOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatR_CQRS_Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersController(ILogger<OrdersController> logger, IMediator mediator) {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetOrderQuery(id));
            return Ok(result);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand order)
        {
            var result = await _mediator.Send(order);
            return Ok(result);
        }

    }
}
