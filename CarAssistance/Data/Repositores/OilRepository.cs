using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class OilRepository : RepositoryBase<OilInfo>, IOilRepo
    {
        public OilRepository(DbContext context) : base(context)
        {
        }
    }
}
