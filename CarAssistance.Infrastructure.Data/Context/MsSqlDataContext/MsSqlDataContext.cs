using CarAssistance.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

public class MsSqlDataContext : BaseDbContext
{
    public MsSqlDataContext(DbContextOptions<MsSqlDataContext> options) : base(options)
    {
    }
}