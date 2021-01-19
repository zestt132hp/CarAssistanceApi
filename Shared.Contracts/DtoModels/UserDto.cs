using System.ComponentModel.DataAnnotations;

namespace Shared.Contracts.DtoModels
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string LogIn { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
