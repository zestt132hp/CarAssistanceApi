using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarAssistance.Controllers.AuthenticationAndAuthorization
{
    public static class AuthToken
    {
        public const string ISSUER = "OAuthApi"; // издатель токена
        public const string AUDIENCE = "OAuthClient"; // потребитель токена
        const string KEY = "0541A4O5!55AP3198OO12P1";   // ключ для шифрации
        public const int LIFETIME = 5; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
