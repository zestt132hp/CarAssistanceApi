using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shared.Identity.Jwt.Model;
using UserAuthApplication.Dto;

namespace Shared.Identity.Jwt
{
    public class JwtBuilder<TIdentityUser, TKey>
        where TIdentityUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
        private UserManager<TIdentityUser> _userManager;
        private JwtSettings _appJwtSettings;
        private TIdentityUser _user;
        private ICollection<Claim> _userClaims;
        private ICollection<Claim> _jwtClaims;
        private ClaimsIdentity _identityClaims;

        public JwtBuilder<TIdentityUser, TKey> WithUserManager(UserManager<TIdentityUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentException(nameof(userManager));
            return this;
        }

        public JwtBuilder<TIdentityUser, TKey> WithJwtSettings(JwtSettings appJwtSettings)
        {
            _appJwtSettings = appJwtSettings ?? throw new ArgumentException(nameof(appJwtSettings));
            return this;
        }

        public JwtBuilder<TIdentityUser, TKey> WithEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentException(nameof(email));

            _user = _userManager.FindByEmailAsync(email).Result;
            _userClaims = new List<Claim>();
            _jwtClaims = new List<Claim>();
            _identityClaims = new ClaimsIdentity();

            return this;
        }

        public JwtBuilder<TIdentityUser, TKey> WithJwtClaims()
        {
            _jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, _user.Id.ToString()));
            _jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Email, _user.Email));
            _jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            _jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            _jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            _identityClaims.AddClaims(_jwtClaims);

            return this;
        }

        public JwtBuilder<TIdentityUser, TKey> WithUserClaims()
        {
            _userClaims = _userManager.GetClaimsAsync(_user).Result;
            _identityClaims.AddClaims(_userClaims);

            return this;
        }

        public JwtBuilder<TIdentityUser, TKey> WithUserRoles()
        {
            var userRoles = _userManager.GetRolesAsync(_user).Result;
            userRoles.ToList().ForEach(r => _identityClaims.AddClaim(new Claim("role", r)));

            return this;
        }

        public string BuildToken()
        {
            var privateKeyByteArray = Convert.FromBase64String(_appJwtSettings.PrivateKey);
            var rsa = RSA.Create();
            RsaSecurityKey RsaKey = new RsaSecurityKey(rsa);
            rsa.ImportRSAPrivateKey(privateKeyByteArray, out _);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor();
            tokenDescriptor.Expires = DateTime.UtcNow.AddHours(_appJwtSettings.ExpirationInMinutes);
            tokenDescriptor.Subject = _identityClaims;
            tokenDescriptor.SigningCredentials = new SigningCredentials(RsaKey, SecurityAlgorithms.RsaSha256);
            tokenDescriptor.Issuer = _appJwtSettings.Issuer;
            tokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(UserIdentityDto.ExpiresMinutes);
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            
            return token;           
        }

        public UserResponse<TKey> BuildUserResponse()
        {
            var user = new UserResponse<TKey>
            {
                AccessToken = BuildToken(),
                ExpiresIn = TimeSpan.FromHours(_appJwtSettings.ExpirationInMinutes).TotalSeconds,
                UserToken = new UserToken<TKey>
                {
                    Id = _user.Id,
                    Email = _user.Email,
                    Claims = _userClaims.Select(c => new UserClaim { Type = c.Type, Value = c.Value })
                }
            };

            return user;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
    }

    public class JwtBuilder<TIdentityUser> : JwtBuilder<TIdentityUser, string> where TIdentityUser : IdentityUser<string> { }

    public sealed class JwtBuilder : JwtBuilder<IdentityUser> { }
}
