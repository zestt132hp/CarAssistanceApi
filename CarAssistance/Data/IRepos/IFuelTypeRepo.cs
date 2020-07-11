using CarAssistance.Models;

namespace CarAssistance.Data.IRepos
{
    public interface IFuelTypeRepo : IRepository<FuelType>
    {
        void Update(FuelType fuelType);
    }
}
