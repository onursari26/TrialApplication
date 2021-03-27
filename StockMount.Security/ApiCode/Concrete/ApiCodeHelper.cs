using Microsoft.Extensions.Configuration;
using Application.Security.ApiCode.Interfaces;
using Application.Security.Jwt.Entities;

namespace Application.Security.ApiCode.Concrete
{
    public class ApiCodeHelper : IApiCodeHelper
    {
        private IConfiguration Configuration { get; }

        public ApiCodeHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public TokenOptions GetApiCodeOptions()
        {
            return Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
    }
}
