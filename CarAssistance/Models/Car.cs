    
namespace CarAssistance.Models
{
    public class Car:CarName
    {
        public int CarNameId { get; set; }
        public int EngineId { get; set; }
        public int GearBoxesId { get; set; }
        public int CarCharcsId { get; set; }
        public int BodyTypeId { get; set; }
        public int TiresId { get; set; }
        public int GarageId { get; set; }

        public GearBoxes GearBox { get; set; }
        public Tires Tires { get; set; }
        public BodyType BodyType { get; set; }
        public Manufacters Manufacter { get; set; }
        public Model Model { get; set; }
        public Engine Engine { get; set; }
        public Garage Garage { get; set; }
        public CarCharacteristics Characteristics { get; set; }
    }
}
