using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace CarAssistance.Data
{
    public class PsgRepository
    {
        private readonly DataContext _db;
        public PsgRepository(IConfiguration configuration)
        {
            _db = new DataContext(new DbContextOptions<DataContext>());
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(configuration["ConnectionString:PsqConnection"]);
            _db = new DataContext(new DbContextOptions<DataContext>());
            _db.Configuring(builder);
        }

        public DataContext GetContext => _db;
    }
}
