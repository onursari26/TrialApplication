using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Api.Attributes;
using Application.Api.Filters;
using Application.Service.OrderService.Queries.Query;
using System.Threading.Tasks;

namespace Application.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(ApiCodeFilter))]

    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/integration/getSales")]
        public async Task<IActionResult> Get([FromBody] GetOrdersQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [Route("api/integration/getTotalOrderCount")]
        public async Task<IActionResult> getTotalOrderCount([FromBody] GetOrdersCount request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
