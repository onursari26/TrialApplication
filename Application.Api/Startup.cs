using Application.Api.Extensions;
using Application.Core.Concrete;
using Application.Core.Context;
using Application.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Application.Logging.Middleware;
using Microsoft.AspNetCore.Http;
using Application.Core.Seeding;
using Application.Utility.StaticMethods;

namespace Application.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InMemoryDatabase = Configuration.GetValue<bool>("UseInMemoryDatabase");
        }

        public IConfiguration Configuration { get; }
        public static string ContentRootPath { get; set; }
        private bool InMemoryDatabase { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            services.AddHttpContextAccessor();

            services.AddFileLog(Configuration);

            services.AddMediatR();

            if (InMemoryDatabase)
                services.AddDbContext<AplicationContext>(ops => ops.UseInMemoryDatabase("AplicationDb"));
            else
                services.AddDbContext<AplicationContext>(ops => ops.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<AplicationContext>));

            services.AddAutoMapper();

            services.AddFilter();

            services.AddAttribute();

            services.AddControllers(configure =>
            {

            }).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
              .AddFluentValidation();

            services.AddService();

            services.AddHttpClient();

            services.AddJwtBearer(Configuration);

            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ContentRootPath = env.ContentRootPath;

            app.UseCors("CorsPolicy");

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });

            AppServiceLocator.Instance = app.ApplicationServices;
            app.UseGlobalExceptionMiddleware();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseRedis(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerExt();
            app.UseSwaggerUI();

            using (var service = app.ApplicationServices.CreateScope())
            {
                var context = service.ServiceProvider.GetService<AplicationContext>();

                if (!InMemoryDatabase)
                    context.Database.Migrate();

                new Seeds().Seed(context);
            }
        }
    }
}
