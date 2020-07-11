using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CarAssistance.Data.Repositores
{
    public class BodyTypeRepository : RepositoryBase<BodyType>, IBodyTypeRepo
    {
        private readonly DbContext _context;
        public BodyTypeRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateAsync(BodyType entity)
        {
            if(entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }
            var model = await FindAsync(entity.Id).ConfigureAwait(false);
            if (model != null)
            {
                model.BodyTypeName = entity.BodyTypeName;
                model.CountDoors = entity.CountDoors;
            }            
        }        
    }
}
