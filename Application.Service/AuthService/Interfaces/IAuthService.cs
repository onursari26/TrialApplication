using Application.Dto.Concrete;
using Application.Dto.Response;
using System.Threading.Tasks;

namespace Application.Service.AuthService.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseInfo<UserDto>> CreateApiCode(ResponseInfo<UserDto> user);
    }
}
