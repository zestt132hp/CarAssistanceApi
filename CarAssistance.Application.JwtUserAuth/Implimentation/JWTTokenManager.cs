using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using UserAuthApplication.Dto;
using UserAuthApplication.Interface;

namespace UserAuthApplication.Implimentation
{
    public class JWTTokenManager : IManager
    {
        public SecurityDto CreateSecuritySession(UserIdentityDto userIdentityDto)
        {
            throw new NotImplementedException();
        }
    }
}
