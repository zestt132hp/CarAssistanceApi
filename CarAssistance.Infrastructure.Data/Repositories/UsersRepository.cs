using CarAssistance.Infrastructure.Data.Interfaces;
using CarAssistance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAssistance.Infrastructure.Data.Repositories
{
    public class UsersRepository : RepositoryBase<Users>, IUsersRepo
    {
        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}
