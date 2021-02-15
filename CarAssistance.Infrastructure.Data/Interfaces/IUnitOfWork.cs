using System.Threading.Tasks;

namespace CarAssistance.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
