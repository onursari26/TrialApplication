using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Api.Filters;
using Application.Service.AuthService.Commands.Command;
using Application.Service.AuthService.Interfaces;
using System.Threading.Tasks;

namespace Application.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(ValidationResultFilter))]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(
            IMediator mediator,
            IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand request)
        {
            var user = await _mediator.Send(request);

            if (!user.IsSuccessfull)
                return Ok(user);

            user = await _authService.CreateApiCode(user);

            return Ok(user);
        }
    }
}
