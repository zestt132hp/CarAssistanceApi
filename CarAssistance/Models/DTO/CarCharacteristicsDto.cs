using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAssistance.Models.DTO
{
    public class CarCharacteristicsDto
    {
        public int MileageRegister { get; set; }
        public OilDto Oil { get; set; }
        public int MileageNow { get; set; }
    }
}
