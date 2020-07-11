using CarAssistance.Models;

namespace CarAssistance.Data.IRepos
{
    public interface IGarageRepo : IRepository<Garage>
    {
        void Update(Garage garageDb);
    }
}
