using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class BodyTypeRepository: IRepository<BodyType>
    {
        private readonly NpgSqlDataContext _db;
        private bool _disposed;
        public BodyTypeRepository(NpgSqlDataContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public BodyType Get(int id)
        {
            return Task.Run(async () => await _db.BodyType.FindAsync(id)).Result;
        }

        public async void Create(BodyType item)
        {
            await _db.BodyType.AddAsync(item);
        }

        public async void Delete(BodyType item)
        {
            await Task.Run(() => _db.BodyType.Remove(item));
        }

        public async void DeleteRange(BodyType[] items)
        {
            await Task.Run(() => _db.BodyType.RemoveRange(items));
        }

        public async void Update(BodyType item)
        {
            await Task.Run(()=> _db.BodyType.Update(item));
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
    }
}
