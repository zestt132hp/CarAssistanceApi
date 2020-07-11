using CarAssistance.Data.IRepos;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Data.Repositores
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepo
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}
