using Application.Service.AuthService.Concrete;
using Application.Service.AuthService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Application.Security.ApiCode.Concrete;
using Application.Security.ApiCode.Interfaces;
using Application.Redis.Interfaces;
using Application.Redis.Concrete;

namespace Application.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApiCodeHelper, ApiCodeHelper>();

            services.AddSingleton<IRedisService, RedisService>();

        }
    }
}
