using System.ComponentModel.DataAnnotations;

namespace Shared.Contracts.DtoModels
{
    public class FuelTypeDto
    {
        [Required]
        public string FuelType { get; set; }
    }
}
