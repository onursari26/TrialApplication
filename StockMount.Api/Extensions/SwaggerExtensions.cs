using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Application.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Adesso Ride Share API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", //Name the security scheme
                 new OpenApiSecurityScheme
                 {
                     Description = "JWT Authorization header using the Bearer scheme.",
                     Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                     Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                 });
            });
        }

        public static void UseSwaggerExt(this IApplicationBuilder app)
        {
            app.UseSwagger();
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
