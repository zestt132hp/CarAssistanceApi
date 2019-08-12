
using System;

namespace CarAssistance.Models
{
    public class CarCharacteristics
    {
        public int CarCharacteristicsId { get; set; }
        public int MileageRegister { get; set; }
        public Oil Oil { get; set; }
        public int MileageNow { get; set; }
        public DateTime Year { get; set; }
        public string Color { get; set; }
    }
}
