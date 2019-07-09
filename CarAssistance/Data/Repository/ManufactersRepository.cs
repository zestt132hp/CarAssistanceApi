using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class ManufactersRepository:IRepository<Manufacter>
    {
        private bool _dispose;
        private readonly DataContext _db;

        public ManufactersRepository(DataContext context)
        {
            _db = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Manufacter Get(int id)
        {
            return Task.Run(async () => await _db.Manufacters.FindAsync(id)).Result;
        }

        public async void Create(Manufacter item)
        {
            await _db.Manufacters.AddAsync(item);
        }

        public void Delete(Manufacter item)
        {
            _db.Manufacters.Remove(item);
        }

        public void DeleteRange(Manufacter[] items)
        {
            _db.Manufacters.RemoveRange(items);
        }

        public void Update(Manufacter item)
        {
            _db.Manufacters.Update(item);
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
    }
}
