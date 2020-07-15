using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class FuelTypeRepository : RepositoryBase<Fuel>, IFuelTypeRepo
    {
        public FuelTypeRepository(DbContext context) : base(context)
        {
        }

        public void Update(Fuel fuelType)
        {
            throw new System.NotImplementedException();
        }
    }
}
