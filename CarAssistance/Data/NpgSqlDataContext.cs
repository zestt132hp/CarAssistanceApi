using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data
{
    public class NpgSqlDataContext : DbContext
    {
        public NpgSqlDataContext(DbContextOptions<NpgSqlDataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder?.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.LogIn).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Phone).IsUnique();
            });
            builder?.HasDefaultSchema("public");
            base.OnModelCreating(builder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Manufacters> Manufacter { get; set; }
        public DbSet<BodyType> BodyType { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarCharacteristics> CarCharacteristics { get; set; }
        public DbSet<BrandTires> BrandTires { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<VehicleDrive> VehicleDrive { get; set; }
        public DbSet<Fuel> FuelType { get; set; }
        public DbSet<Tires> Tires { get; set; }
        public DbSet<Garage> Garage { get; set; }
        public DbSet<GearBoxes> GearBox { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelTires> ModelTires { get; set; }
        public DbSet<OilInfo> OilInfo { get; set; }
        public DbSet<Notes> Notes { get; set; }
    }
}
