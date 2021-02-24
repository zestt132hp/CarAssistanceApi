namespace Shared.Identity.Jwt
{
    public class JwtSettings
    {
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public int ExpirationInMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

    }
}
