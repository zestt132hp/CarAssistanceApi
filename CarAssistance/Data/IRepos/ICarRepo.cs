using CarAssistance.Models;

namespace CarAssistance.Data.IRepos
{
    public interface ICarRepo : IRepository<Car>
    {
        void Update(Car result);
    }
}
