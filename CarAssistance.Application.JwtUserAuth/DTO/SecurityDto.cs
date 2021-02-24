using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace UserAuthApplication.Dto
{
    public class SecurityDto
    {
        public string Token { get; set; }
        
        public string PublicKey { get; set; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }     
    }
}
