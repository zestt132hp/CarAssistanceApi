using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data
{
    public class SqlDataContext
    {
        private readonly DataContext _db;
        public SqlDataContext(IConfiguration configuration)
        {
            _db = new DataContext(new DbContextOptions<DataContext>());
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configuration["ConnectionString:SqlConnection"]);
            _db = new DataContext(new DbContextOptions<DataContext>());
            _db.Configuring(builder);
        }

        public DataContext GetContext => _db;
    }
}
