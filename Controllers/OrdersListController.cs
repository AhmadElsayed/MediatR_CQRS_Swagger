using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatR_CQRS_Swagger.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatR_CQRS_Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersListController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersListController(ILogger<OrdersController> logger, IMediator mediator) {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetOrdersListQuery());
            return Ok(result);
        }

    }
}
