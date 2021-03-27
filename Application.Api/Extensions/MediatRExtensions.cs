using Application.Service.AuthService.Commands.Command;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Application.Service.OrderService.Queries.Query;

namespace Application.Api.Extensions
{
    public static class MediatRExtensions
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(UserLoginCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetOrdersQuery).GetTypeInfo().Assembly);
        }
    }
}
