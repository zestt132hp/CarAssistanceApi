using CarAssistance.Models;

namespace CarAssistance.Data.IRepos
{
    public interface IEngineRepo : IRepository<Engine>
    {
        void Update(Engine engineUnit);
    }
}
