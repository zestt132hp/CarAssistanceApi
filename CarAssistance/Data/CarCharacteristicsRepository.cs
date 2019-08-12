using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class CarCharacteristicsRepository: IRepository<CarCharacteristics>
    {
        private readonly NpgSqlDataContext _db;
        private bool _disposed;
        public CarCharacteristicsRepository(NpgSqlDataContext db)
        {
            _db = db;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public CarCharacteristics Get(int id)
        {
            return Task.Run(async () => await _db.CarCharacteristics.FindAsync(id)).Result;
        }

        public async void Create(CarCharacteristics item)
        {
            await _db.CarCharacteristics.AddAsync(item);
        }

        public async void Delete(CarCharacteristics item)
        {
            await Task.Run(()=>_db.CarCharacteristics.Remove(item));
        }

        public async void DeleteRange(CarCharacteristics[] items)
        {
            await Task.Run(() => _db.CarCharacteristics.RemoveRange(items));
        }

        public async void Update(CarCharacteristics item)
        {
            await Task.Run(() => _db.CarCharacteristics.Update(item));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    _db.Dispose();
                }

                _disposed = false;
            }
        }
    }
}
