using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class ManufactersRepository:IRepository<Manufacter>
    {
        private bool _dispose;
        private readonly NpgSqlDataContext _data;

        public ManufactersRepository(NpgSqlDataContext context)
        {
            _data = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Manufacter Get(int id)
        {
            return Task.Run(async () => await _data.Manufacter.FindAsync(id)).Result;
        }

        public async void Create(Manufacter item)
        {
            await _data.Manufacter.AddAsync(item);
        }

        public void Delete(Manufacter item)
        {
            _data.Manufacter.Remove(item);
        }

        public void DeleteRange(Manufacter[] items)
        {
            _data.Manufacter.RemoveRange(items);
        }

        public void Update(Manufacter item)
        {
            _data.Manufacter.Update(item);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_dispose)
                {
                    _data.Dispose();
                }
                _dispose = true;
            }
        }
    }
}
