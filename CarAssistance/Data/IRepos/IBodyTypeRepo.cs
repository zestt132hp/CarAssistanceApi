using CarAssistance.Models;
using System.Threading.Tasks;

namespace CarAssistance.Data.IRepos
{
    public interface IBodyTypeRepo:IRepository<BodyType>
    {
        Task UpdateAsync(BodyType entity);
    }
}
