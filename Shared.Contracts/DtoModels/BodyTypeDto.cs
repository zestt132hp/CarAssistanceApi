using System.ComponentModel.DataAnnotations;

namespace Shared.Contracts.DtoModels
{
    public class BodyTypeDto
    {
        [Required]
        public string BodyTypeName { get; set; }
        [Required]
        public int CountDoors { get; set; }
    }
}
