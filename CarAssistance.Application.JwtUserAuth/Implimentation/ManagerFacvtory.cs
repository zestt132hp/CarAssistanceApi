using System;
using UserAuthApplication.Interface;

namespace UserAuthApplication.Implimentation
{
    public class ManagerFacvtory : IManagerFactory
    {
        public IManager GetManager(object someData)
        {
            if (someData.Equals(null)) 
            {
                throw new NullReferenceException("Can't create security manager");
            }
            return new JWTTokenManager();
        }
    }
}
