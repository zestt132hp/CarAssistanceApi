using AutoMapper;
using CarAssistance.Data;
using CarAssistance.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarAssistance.Configuration.SwaggerConfigurationExtension;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CarAssistance
{
    /// <summary>
    /// Point start up
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configuration">configuration for start up</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configSection = Configuration.GetSection("ConnectionString:PsgConnection");
            services.AddDbContext<Data.NpgSqlDataContext>(optionsAction =>
            {
                optionsAction.UseNpgsql(configSection.Value);
            });
            services.AddScoped<DbContext, Data.NpgSqlDataContext>();
            services.AddScoped<IUnitOfWork, UoW>();

            var mappingConfig = new MapperConfiguration(conf => { conf.AddProfile(new Data.MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
            services.AddSwaggerConfiguration();
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/login");
                    option.AccessDeniedPath = "/Account/logout";
                })
                .AddJwtBearer(option =>
                {
                    option.Authority = "https://localhost:5001/";
                    option.Audience = "https://localhost:5001/Account/Login";
                });

            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">application builder</param>
        /// <param name="env">host environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseHsts();
            }
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            app.UseSwaggerSetup();

            app.UseHttpsRedirection();
        }
    }
}
