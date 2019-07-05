using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data
{
    public class DataContext : DbContext
    {
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
             optionsBuilder.UseNpgsql("Host");*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.LogIn).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Phone).IsUnique();
            });
        }

        public DbSet<BodyType> BodyTypes;
        public DbSet<Car> Cars;
        public DbSet<CarCharacteristics> CarCharacteristics;
        public DbSet<Engine> Engines;
        public DbSet<FuelType> FuelTypes;
        public DbSet<Garage> Garages;
        public DbSet<GearBox> GearBoxes;
        public DbSet<Manufacter> Manufacters;
        public DbSet<Model> Models;
        public DbSet<Tires> Tires;
        public DbSet<VehicleDrive> VehicleDrives;
        public DbSet<Users> Users;
        public DbSet<Oil> Oils;
    }
}
