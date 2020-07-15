using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class ManufacterRepository : RepositoryBase<Manufacters>, IManufacterRepo
    {
        public ManufacterRepository(DbContext context) : base(context)
        {
        }
    }
}
