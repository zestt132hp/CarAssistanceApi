using System;
using System.Threading.Tasks;
using CarAssistance.Models;

namespace CarAssistance.Data.Repository
{
    public class BodyTypeRepository:BaseRepository, IRepository<BodyType>
    {
        public BodyTypeRepository(DataContext context):base(context)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public BodyType Get(int id)
        {
            return Task.Run(async () => await _db.BodyTypes.FindAsync(id)).Result;
        }

        public async void Create(BodyType item)
        {
            await _db.BodyTypes.AddAsync(item);
        }

        public async void Delete(BodyType item)
        {
            await Task.Run(() => _db.BodyTypes.Remove(item));
        }

        public async void DeleteRange(BodyType[] items)
        {
            await Task.Run(() => _db.BodyTypes.RemoveRange(items));
        }

        public async void Update(BodyType item)
        {
            await Task.Run(()=> _db.BodyTypes.Update(item));
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
