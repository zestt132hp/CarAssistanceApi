using System;
using CarAssistance.Data.Repository;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarAssistance.Data
{
    public class UnitOfWork:IDisposable
    {
        private readonly NpgSqlDataContext _context;
        private GenericRepository<Car> _carsRepository;
        private GenericRepository<Manufacter> _brandsRepository;
        private GenericRepository<Tires> _tiresRepository;
        private GenericRepository<Model> _modelsRepository;
        private GenericRepository<Engine> _enginesRepository;
        private GenericRepository<BodyType> _bodyTypeRepository;
        private GenericRepository<CarCharacteristics> _carCharacteristicsRepository;
        private GenericRepository<FuelType> _fuelTypeRepository;
        private GenericRepository<Garage> _garageRepository;
        private GenericRepository<GearBox> _gearBoxRepository;
        private GenericRepository<Oil> _oilRepository;
        private GenericRepository<Users> _useRepository;
        private GenericRepository<VehicleDrive> _vehicleRepository;
        private bool _disposed;


        public UnitOfWork(IConfiguration config)
        {
            _context = new NpgSqlDataContext(new DbContextOptions<NpgSqlDataContext>(), config);
        }

        public GenericRepository<Car> CarsRepos =>
            _carsRepository ?? (_carsRepository = new GenericRepository<Car>(_context));

        public GenericRepository<Manufacter> ManufactersRepos => _brandsRepository ?? (_brandsRepository = new GenericRepository<Manufacter>(_context));

        public GenericRepository<Tires> TiresRepos =>
            _tiresRepository ?? (_tiresRepository = new GenericRepository<Tires>(_context));

        public GenericRepository<Model> ModelsRepos =>
            _modelsRepository ?? (_modelsRepository = new GenericRepository<Model>(_context));

        public GenericRepository<Engine> EnginesRepos =>
            _enginesRepository ?? (_enginesRepository = new GenericRepository<Engine>(_context));

        public GenericRepository<BodyType> BodyTypesRepos =>
            _bodyTypeRepository ?? (_bodyTypeRepository = new GenericRepository<BodyType>(_context));

        public GenericRepository<CarCharacteristics> CarCharacteristicsRepos =>
            _carCharacteristicsRepository ??
            (_carCharacteristicsRepository = new GenericRepository<CarCharacteristics>(_context));

        public GenericRepository<FuelType> FuelTypeRepos =>
            _fuelTypeRepository ?? (_fuelTypeRepository = new GenericRepository<FuelType>(_context));

        public GenericRepository<Oil> OilRepos =>
            _oilRepository ?? (_oilRepository = new GenericRepository<Oil>(_context));

        public GenericRepository<Garage> GarageRepos =>
            _garageRepository ?? (_garageRepository = new GenericRepository<Garage>(_context));

        public GenericRepository<GearBox> GearsRepos =>
            _gearBoxRepository ?? (_gearBoxRepository = new GenericRepository<GearBox>(_context));

        public GenericRepository<Users> UsersRepos =>
            _useRepository ?? (_useRepository = new GenericRepository<Users>(_context));

        public GenericRepository<VehicleDrive> VehicleDriveRepos =>
            _vehicleRepository ?? (_vehicleRepository = new GenericRepository<VehicleDrive>(_context));

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
