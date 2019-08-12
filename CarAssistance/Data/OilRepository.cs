using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class OilRepository: IRepository<Oil>
    {
        private NpgSqlDataContext Db;
        private bool _disposed;
        public OilRepository(NpgSqlDataContext db)
        {
            Db = db;
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
                    Db.Dispose();
                }
                _disposed = true;
            }
        }

        public Oil Get(int id)
        {
            return Task.Run(async ()=> await Db.Oil.FindAsync(id)).Result;
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
