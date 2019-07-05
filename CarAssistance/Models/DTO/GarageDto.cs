using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAssistance.Models.DTO
{
    public class GarageDto
    {
        public List<CarDto> Cars { get; set; }
        public UserDto User { get; set; }
    }
}
