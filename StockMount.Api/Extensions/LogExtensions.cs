using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Application.Logging.Middleware;

namespace Application.Api.Extensions
{
    public static class LogExtensions
    {
        public static void AddFileLog(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .Enrich.With(new HttpContextEnricher())
                            .CreateLogger();
        }
    }
}
