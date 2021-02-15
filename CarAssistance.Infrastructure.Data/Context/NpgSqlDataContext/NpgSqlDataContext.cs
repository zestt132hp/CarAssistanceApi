using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Infrastructure.Data.Context.NpgSqlDataContext
{
    public class NpgSqlDataContext : BaseDbContext
    {
        public NpgSqlDataContext(DbContextOptions<NpgSqlDataContext> options) : base(options)
        {
        }        
    }
}
