using CarAssistance.Identity.Identity;
using CarAssistance.Security.Api.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarAssistance.Security.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Add DbContext
            services.AddDbConnection(Configuration);

            // ASP.NET Identity Settings
            services.AddApiIdentityConfiguration(Configuration);
                        
            // AutoMapper Settings
            //services.AddAutoMapperConfiguration();

            // Adding MediatR for Domain Events and Notifications
            //services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            //services.AddDependencyInjectionConfiguration();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
