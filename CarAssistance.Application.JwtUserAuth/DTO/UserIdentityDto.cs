using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace UserAuthApplication.Dto
{
    public class UserIdentityDto
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string Password { get; set; }
        public object Role { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; internal set; }
        public string PublicKey { get; set; }

        public const int ExpiresMinutes = 20;
    }
}
