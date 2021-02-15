
using System.ComponentModel.DataAnnotations;

namespace CarAssistance.Models
{
    public class GearBoxes
    {
        public int Id { get; set; }
        [Required]
        public string GearBoxType { get; set; }
        [Required]
        public int CountGears { get; set; }
        public string NumberGearBox { get; set; }
        public int VehicleDriveId { get; set; }
        [Required]
        public string GearNumber { get; set; }
    }
}
