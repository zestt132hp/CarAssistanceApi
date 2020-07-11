using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class FuelTypeRepository : RepositoryBase<FuelType>, IFuelTypeRepo
    {
        public FuelTypeRepository(DbContext context) : base(context)
        {
        }

        public void Update(FuelType fuelType)
        {
            throw new System.NotImplementedException();
        }
    }
}
