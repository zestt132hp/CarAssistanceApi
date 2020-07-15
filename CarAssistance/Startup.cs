using AutoMapper;
using CarAssistance.Data;
using CarAssistance.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            //{
            //    option.RequireHttpsMetadata = true;
            //    option.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = AuthToken.ISSUER,
            //        // будет ли валидироваться потребитель токена
            //        ValidateAudience = true,
            //        // установка потребителя токена
            //        ValidAudience = AuthToken.AUDIENCE,
            //        // будет ли валидироваться время существования
            //        ValidateLifetime = true,

            //        // установка ключа безопасности
            //        IssuerSigningKey = AuthToken.GetSymmetricSecurityKey(),
            //        // валидация ключа безопасности
            //        ValidateIssuerSigningKey = true,
            //    };
            //});

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
            services.AddSpaStaticFiles(config => config.RootPath = "ClientApp/dist");
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseSpa(spa => spa.Options.SourcePath = "ClientApp");
            if (env.IsDevelopment())
            {
                //app.UseSpa(spa => spa.UseAngularCliServer("start"));
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endPoints =>
                endPoints.MapControllers());

            //app.UseAuthentication();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseOpenApi();
            //app.UseHttpsRedirection();

            //app.UseSpaStaticFiles();
        }
    }
}
