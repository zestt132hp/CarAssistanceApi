    
namespace CarAssistance.Models
{
    public class Car:CarName
    {
        public int Car_Name_Id { get; set; }
        public int Engine_Id { get; set; }
        public int Car_Charcs_Id { get; set; }

        public Manufacter Manufacter { get; set; }
        public Model Model { get; set; }
        public Engine Engine { get; set; }
        public int GearBoxes_Id { get; set; }
        public GearBox GearBox { get; set; }
        public int BodyType_Id { get; set; }
        public BodyType BodyType { get; set; }
        public int Tires_Id { get; set; }
        public Tires Tires { get; set; }

        public Car_Characteristics Characteristics { get; set; }
    }
}
