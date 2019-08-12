using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAssistance.Models.DTO;

namespace CarAssistance.Data.Repository
{
    public class UsersRepository:IRepository<UserDto>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(UserDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserDto item)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(UserDto[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDto item)
        {
            throw new NotImplementedException();
        }
    }
}
