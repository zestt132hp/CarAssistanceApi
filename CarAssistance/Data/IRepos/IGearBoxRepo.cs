using CarAssistance.Models;
using System.Threading.Tasks;

namespace CarAssistance.Data.IRepos
{
    public interface IGearBoxRepo : IRepository<GearBoxes>
    {
        void Update(GearBoxes gearBox);
        Task UpdateAsync(GearBoxes gearBox);
    }
}
