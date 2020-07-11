using CarAssistance.Data.IRepos;
using System;

namespace CarAssistance.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IBodyTypeRepo BodyTypeRepository { get; }
        public ICarRepo CarRepository { get; }
        public IUsersRepo UsersRepository { get; }
        public IEngineRepo EngineRepository { get; } 
        public IFuelTypeRepo FuelTypeRepository { get; }
        public IGearBoxRepo GearBoxRepo { get; }
        public IGarageRepo GarageRepos { get; }

        void Commit();
        System.Threading.Tasks.Task CommitAsync();
    }
}
