using System;
using System.Threading.Tasks;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarAssistance.Data.Repository
{
    public class ModelRepository:IRepository<Model>
    {
        private bool _dispose;
        private readonly DataContext _db;

        public ModelRepository(IConfiguration configuration)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configuration["ConnectionString:SqlConnection"]);
            _db = new DataContext(new DbContextOptions<DataContext>());
            _db.Configuring(builder);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Model Get(int id)
        {
            return Task.Run(async () =>await _db.Models.FindAsync(id)).Result;
        }

        public async void Create(Model item)
        {
            await _db.Models.AddAsync(item);
        }

        public void Delete(Model item)
        {
            _db.Models.Remove(item);
        }

        public void DeleteRange(Model[] items)
        {
            _db.Models.RemoveRange(items);
        }

        public void Update(Model item)
        {
            _db.Models.Update(item);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
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
