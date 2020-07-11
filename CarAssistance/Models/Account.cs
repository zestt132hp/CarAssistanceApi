using System;

namespace CarAssistance.Models
{
    public class Account
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDATE { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
