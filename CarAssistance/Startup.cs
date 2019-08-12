using AutoMapper;
using CarAssistance.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkNpgsql().AddDbContext<NpgSqlDataContext>().BuildServiceProvider();
            services.AddSingleton(Configuration);
            services.AddSpaStaticFiles(config => config.RootPath = "ClientApp/dist");
            var mappingConfig = new MapperConfiguration(conf => { conf.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerDocument(conf =>
            {
                conf.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "CarAssistance API";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Nikolay Anikeev",
                        Email = "n.anikeev@gmail.com",
                        Url = "https://github.com/zestt132hp"
                    };
                };
            });

            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">application builder</param>
        /// <param name="env">host environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
