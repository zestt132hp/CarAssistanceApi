using System;
using System.Collections.Generic;
using System.Text;
using UserAuthApplication.Dto;

namespace UserAuthApplication.Interface
{
    public interface IManager
    {
        SecurityDto CreateSecuritySession(UserIdentityDto userIdentityDto);
    }
}
