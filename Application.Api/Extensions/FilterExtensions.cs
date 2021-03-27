using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Application.Api.Filters;
using System;

namespace Application.Api.Extensions
{
    public static class FilterExtensions
    {
        public static void AddFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidationResultFilter>();
        }
    }
}
