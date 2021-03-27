using MediatR;
using Newtonsoft.Json;
using Application.Dto.Concrete;
using Application.Dto.Response;

namespace Application.Service.AuthService.Commands.Command
{
    public class UserLoginCommand : IRequest<ResponseInfo<UserDto>>
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
