using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class CarCharacteristicsRepository : RepositoryBase<CarCharacteristics>, ICarCharacteristicsRepo
    {
        public CarCharacteristicsRepository(DbContext context) : base(context)
        {
        }
    }
}
