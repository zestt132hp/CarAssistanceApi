using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Linq;

namespace CarAssistance.Configuration.SwaggerConfigurationExtension
{
    public static class SwaggerConfExtension
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services) 
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerDocument(conf =>
            {
                conf.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme 
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                conf.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

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
        }       

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }   
    }
}
