using Microsoft.Extensions.DependencyInjection;
using Application.Api.Attributes;

namespace Application.Api.Extensions
{
    public static class AttributeExtensions
    {
        public static void AddAttribute(this IServiceCollection services)
        {
            services.AddScoped<ApiCodeFilter>();
        }
    }
}
