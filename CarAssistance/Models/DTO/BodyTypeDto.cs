
using System.ComponentModel.DataAnnotations;

namespace CarAssistance.Models.DTO
{
    public class BodyTypeDto
    {
        [Required]
        public string BodyTypeName { get; set; }
        [Required]
        public string CountDoors { get; set; }
    }
}
