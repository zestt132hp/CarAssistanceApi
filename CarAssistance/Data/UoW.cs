using CarAssistance.Data.IRepos;
using CarAssistance.Data.Repositores;
using CarAssistance.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarAssistance.Data
{
    public class UoW : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposable;

        private IBodyTypeRepo _bodyTypeRepo;
        private ICarRepo _carRepo;
        private IUsersRepo _usersRepo;
        private IEngineRepo _engineRepo;
        private IFuelTypeRepo _fuelTypeRepo;
        private IGearBoxRepo _gearBoxRepo;
        private IGarageRepo _garageRepository;

        public UoW(DbContext dbContext)
        {
            _context = dbContext;
        }

        // TODO: Использовать фабрику репозиториев по типу

        public IBodyTypeRepo BodyTypeRepository => _bodyTypeRepo ?? new BodyTypeRepository(_context);

        public ICarRepo CarRepository => _carRepo ?? new CarRepository(_context);

        public IUsersRepo UsersRepository => _usersRepo ?? new UsersRepository(_context);

        public IEngineRepo EngineRepository => _engineRepo ?? new EngineRepository(_context);

        public IFuelTypeRepo FuelTypeRepository => _fuelTypeRepo ?? new FuelTypeRepository(_context);

        public IGearBoxRepo GearBoxRepo => _gearBoxRepo ?? new GearBoxRepository(_context);

        public IGarageRepo GarageRepos => _garageRepository ?? new GarageRepository(_context);

        public void Commit()
        {
            if (!_disposable) 
            {
                _context.SaveChanges();
            }
        }
        public async System.Threading.Tasks.Task CommitAsync()
        {
            if (!_disposable) 
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (!_disposable) 
                {
                    _disposable = true;
                    _context.Dispose();
                }
            }
        }
        ~UoW()
        {
            Dispose(false);
        }
    }
}
