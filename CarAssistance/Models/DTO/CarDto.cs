
namespace CarAssistance.Models.DTO
{
    public class CarDto
    {
        public Manufacters Manufacter { get; set; }
        public Model Model { get; set; }
        public EngineDto Engine { get; set; }
        public GearBoxDto GearBox { get; set; }
        public BodyTypeDto BodyType { get; set; }
        public TiresDto Tires { get; set; }
        public CarCharacteristicsDto Characteristics { get; set; }
    }
}
