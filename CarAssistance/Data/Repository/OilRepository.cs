using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class OilRepository:BaseRepository, IRepository<Oil>
    {
        public OilRepository(DataContext db) : base(db)
        {
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
                if (!_dispose)
                {
                    _db.Dispose();
                }
                _dispose = true;
            }
        }

        public Oil Get(int id)
        {
            return Task.Run(async ()=> await _db.Oils.FindAsync(id)).Result;
        }

        public void Create(Oil item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Oil item)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(Oil[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(Oil item)
        {
            throw new NotImplementedException();
        }
    }
}
