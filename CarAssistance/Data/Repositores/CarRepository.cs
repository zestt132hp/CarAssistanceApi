using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class CarRepository : RepositoryBase<Car>, ICarRepo
    {
        private readonly DbContext _context;
        public CarRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Car result)
        {
            throw new System.NotImplementedException();
        }
    }
}
