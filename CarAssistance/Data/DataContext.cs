using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host");

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
    }
}
