using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarAssistance.Data.Repositores
{
    public class GearBoxRepository : RepositoryBase<GearBoxes>, IGearBoxRepo
    {
        public GearBoxRepository(DbContext context) : base(context)
        {
        }

        public void Update(GearBoxes gearBox)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(GearBoxes gearBox)
        {
            throw new System.NotImplementedException();
        }
    }
}
