using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class ManufacterRepository : RepositoryBase<Manufacter>, IManufacterRepo
    {
        public ManufacterRepository(DbContext context) : base(context)
        {
        }
    }
}
