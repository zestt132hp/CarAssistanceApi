using CarAssistance.Controllers.AuthenticationAndAuthorization;
using CarAssistance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using CarAssistance.Data.Repository;

namespace CarAssistance.Controllers
{
    [Route("/auth")]
    public class AccountController:ControllerBases
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet, Route("")]
        public ViewResult AuthPage()
        {
            return null; // View("StaticFiles/index.html");
        }
        [HttpPost("/token")]
        public IActionResult Token(string logIn, string password)
        {
            if (string.IsNullOrEmpty(logIn) || string.IsNullOrEmpty(password))
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
            Users user = new Users()
            {
                LogIn = logIn,
                Password = password
            };
            var userAccount = _unitOfWork.UsersRepository.GetByExpression(user => user.LogIn == logIn
                       && user.Password == password);
            if(userAccount == null)
            {
                return BadRequest(new { errorText = $"user with this logIn {logIn} " +
                    $"  \n and password {password} an not exists" });
            }
            var identity = GetIdentityClaims(user);
            
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthToken.ISSUER,
                    audience: AuthToken.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthToken.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthToken.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return null;
            //return Json(response);
        }


        private static ClaimsIdentity GetIdentityClaims(Users user)
        {
            Person person = new Person()
            {
                Login = user.LogIn,
                Mail = user.Email,
                Password = user.Password
            };
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;

        }
    }
}
