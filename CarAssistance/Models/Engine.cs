
namespace CarAssistance.Models
{
    public class Engine
    {
        public int EngineId { get; set; }
        public FuelType Fuel { get; set; }
        public int CountHp { get; set; }
        public int CountKw { get; set; }
        public double CapacityEngine { get; set; }
        public string EngineNumber { get; set; }

    }
}
