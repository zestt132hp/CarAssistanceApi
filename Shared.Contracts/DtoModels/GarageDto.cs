using System.Collections.Generic;

namespace Shared.Contracts.DtoModels
{
    public class GarageDto
    {
        public List<CarDto> Cars { get; set; }
        public UserDto User { get; set; }
    }
}
