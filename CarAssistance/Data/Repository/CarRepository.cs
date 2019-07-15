using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class CarRepository: IRepository<Car>
    {
        private readonly NpgSqlDataContext _db;
        private bool _disposed;
        public CarRepository(NpgSqlDataContext context)
        {
            _db = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    _db.Dispose();
                }

                _disposed = true;
            }
        }

        public Car Get(int id)
        {
            return Task.Run(async () => await _db.Car.FindAsync(id)).Result;
        }

        public void Create(Car item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car item)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(Car[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(Car item)
        {
            throw new NotImplementedException();
        }

       
    }
}
