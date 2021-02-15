using CarAssistance.Infrastructure.Data.Context.NpgSqlDataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarAssistance.Security.Api.Configs
{
    public static class DatabaseConfigServiceCollectionExtension
    {
        public static void AddPostgresDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<NpgSqlDataContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ConnectionString:PsgConnection")));
        }

        public static void AddMssqlDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<MsSqlDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString:SqlConnection")));
        }

        public static void AddDbConnection(this IServiceCollection services, IConfiguration configuration) 
        {
            var useSql = configuration.GetValue<bool>("UseMsSql");
            if (useSql)
            {
                services.AddMssqlDataBaseConfiguration(configuration);
            }
            else
            {
                services.AddPostgresDatabaseConfiguration(configuration);
            }
        }
    }
}
