using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarAssistance.Models.DTO
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
