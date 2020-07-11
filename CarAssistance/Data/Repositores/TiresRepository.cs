using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class TiresRepository : RepositoryBase<Tires>, ITiresRepo
    {
        public TiresRepository(DbContext context) : base(context)
        {
        }
    }
}
