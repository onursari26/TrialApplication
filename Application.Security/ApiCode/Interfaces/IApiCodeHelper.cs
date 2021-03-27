using Application.Security.Jwt.Entities;

namespace Application.Security.ApiCode.Interfaces
{
    public interface IApiCodeHelper
    {
        TokenOptions GetApiCodeOptions();
    }
}
