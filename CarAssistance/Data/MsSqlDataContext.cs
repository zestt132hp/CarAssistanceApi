using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarAssistance.Data
{
    public class MsSqlDataContext:DbContext
    {
        private readonly IConfiguration _config;
        public MsSqlDataContext(DbContextOptions<MsSqlDataContext> options, IConfiguration configuration) : base(options)
        {
            _config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config["ConnectionString:SqlConnection"]);
        }
    }
}
