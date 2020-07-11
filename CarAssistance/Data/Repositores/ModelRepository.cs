using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class ModelRepository : RepositoryBase<Model>, IModelRepo
    {
        public ModelRepository(DbContext context) : base(context)
        {
        }
    }
}
