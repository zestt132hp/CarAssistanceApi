
namespace Shared.Contracts.DtoModels
{
    public class CarDto
    {
        public ManufacterDto Manufacter { get; set; }
        public ModelDto Model { get; set; }
        public EngineDto Engine { get; set; }
        public GearBoxDto GearBox { get; set; }
        public BodyTypeDto BodyType { get; set; }
        public TiresDto Tires { get; set; }
        public CarCharacteristicsDto Characteristics { get; set; }
    }
}
