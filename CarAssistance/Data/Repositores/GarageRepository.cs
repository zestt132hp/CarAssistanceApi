using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class GarageRepository : RepositoryBase<Garage>, IGarageRepo
    {
        public GarageRepository(DbContext context) : base(context)
        {
        }

        public void Update(Garage garageDb)
        {
            throw new System.NotImplementedException();
        }
    }
}
