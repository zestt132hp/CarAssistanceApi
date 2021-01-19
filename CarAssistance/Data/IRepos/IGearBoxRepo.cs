using CarAssistance.Models;
using System.Threading.Tasks;

namespace CarAssistance.Data.IRepos
{
    public interface IGearBoxRepo : IRepository<GearBox>
    {
        void Update(GearBox gearBox);
        Task UpdateAsync(GearBox gearBox);
    }
}
