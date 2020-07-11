using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class EngineRepository : RepositoryBase<Engine>, IEngineRepo
    {
        public EngineRepository(DbContext context) : base(context)
        {
        }

        public void Update(Engine engineUnit)
        {
            throw new System.NotImplementedException();
        }
    }
}
