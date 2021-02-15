
using System;

namespace CarAssistance.Models
{
    public class CarCharacteristics
    {
        public int Id { get; set; }
        public int OilInfoId { get; set; }
        public int MileageRegister { get; set; }
        public int MileageNow { get; set; }
        public DateTime Year { get; set; }
        public string Color { get; set; }

        public OilInfo Oil { get; set; }
    }
}
