
namespace CarAssistance.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public int FuelId { get; set; }
        public int CountHPower { get; set; }
        public int CountKwt { get; set; }
        public double CapacityEngine { get; set; }
        public string EngineNumber { get; set; }


        public Fuel Fuel { get; set; }

    }
}
