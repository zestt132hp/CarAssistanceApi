using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthApplication.Interface
{
    interface IManagerFactory
    {
        IManager GetManager(object someData);
    }
}
