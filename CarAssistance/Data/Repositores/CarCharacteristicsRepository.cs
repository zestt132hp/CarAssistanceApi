using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class CarCharacteristicsRepository : RepositoryBase<Car_Characteristics>, ICarCharacteristicsRepo
    {
        public CarCharacteristicsRepository(DbContext context) : base(context)
        {
        }
    }
}
