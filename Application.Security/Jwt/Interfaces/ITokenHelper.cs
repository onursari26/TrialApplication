using Application.Dto.Concrete;

namespace Application.Security.Jwt.Interfaces
{
    public interface ITokenHelper
    {
        UserDto CreateToken(UserDto user);
    }
}
