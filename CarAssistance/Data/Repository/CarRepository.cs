using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class CarRepository:BaseRepository, IRepository<Car>
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_dispose)
                {
                    _db.Dispose();
                }

                _dispose = true;
            }
        }

        public Car Get(int id)
        {
            return Task.Run(async () => await _db.Cars.FindAsync(id)).Result;
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

        public CarRepository(DataContext db) : base(db)
        {
        }
    }
}
