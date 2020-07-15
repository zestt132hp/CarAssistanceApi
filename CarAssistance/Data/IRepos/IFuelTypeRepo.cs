using CarAssistance.Models;

namespace CarAssistance.Data.IRepos
{
    public interface IFuelTypeRepo : IRepository<Fuel>
    {
        void Update(Fuel fuelType);
    }
}
