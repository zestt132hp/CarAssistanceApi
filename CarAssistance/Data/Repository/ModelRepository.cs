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
        private readonly NpgSqlDataContext _data;

        public ModelRepository(IConfiguration configuration)
        {
            /*DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configuration["ConnectionString:SqlConnection"]);
            _data = new DataContext(new DbContextOptions<DataContext>());
            _data.Configuring(builder);*/
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Model Get(int id)
        {
            return Task.Run(async () =>await _data.Models.FindAsync(id)).Result;
        }

        public async void Create(Model item)
        {
            await _data.Models.AddAsync(item);
        }

        public void Delete(Model item)
        {
            _data.Models.Remove(item);
        }

        public void DeleteRange(Model[] items)
        {
            _data.Models.RemoveRange(items);
        }

        public void Update(Model item)
        {
            _data.Models.Update(item);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
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
