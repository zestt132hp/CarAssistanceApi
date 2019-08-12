    
namespace CarAssistance.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public int ManufacterId { get; set; }
        public Manufacter Manufacter { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int GearBoxId { get; set; }
        public GearBox GearBox { get; set; }
        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        public int TiresId { get; set; }
        public Tires Tires { get; set; }
        public int CharacteristicsId { get; set; }

        public CarCharacteristics Characteristics { get; set; }
    }
}
