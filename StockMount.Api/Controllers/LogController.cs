using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Api.Attributes;
using Application.Service.LogService.Queries.Query;
using System.Threading.Tasks;

namespace Application.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(ApiCodeFilter))]
    public class LogController : BaseController
    {
        public LogController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/log/get")]
        public async Task<IActionResult> Get([FromBody] GetLogsQuery request)
        {
            request.FilePath = Startup.ContentRootPath;

            return Ok(await _mediator.Send(request));
        }
    }
}
