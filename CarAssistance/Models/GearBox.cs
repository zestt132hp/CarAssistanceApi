
using System.ComponentModel.DataAnnotations;

namespace CarAssistance.Models
{
    public class GearBox
    {
        public int GearBoxId { get; set; }
        [Required]
        public string GearBoxType { get; set; }
        [Required]
        public int CountGear { get; set; }
        [Required]
        public string GearNumber { get; set; }
    }
}
