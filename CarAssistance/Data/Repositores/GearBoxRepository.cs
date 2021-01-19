using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarAssistance.Data.Repositores
{
    public class GearBoxRepository : RepositoryBase<GearBox>, IGearBoxRepo
    {
        public GearBoxRepository(DbContext context) : base(context)
        {
        }

        public void Update(GearBox gearBox)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(GearBox gearBox)
        {
            throw new System.NotImplementedException();
        }
    }
}
