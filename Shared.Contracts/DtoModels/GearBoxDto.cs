using System.ComponentModel.DataAnnotations;

namespace Shared.Contracts.DtoModels
{
    public class GearBoxDto
    {
        [Required]
        public string GearBoxType { get; set; }
        [Required]
        public int CountGear { get; set; }
        [Required]
        public string GearNumber { get; set; }
    }
}
