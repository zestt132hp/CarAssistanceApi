

namespace CarAssistance.Models
{
    public class Tires
    {
        public int TiresId { get; set; }

        public TiresSeason  Season { get; set; }
        public int YearStartSale { get; set; }
        public BrandTires Brand { get; set; }
        public ModelTires Model { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public double Radius { get; set; }

    }

    public class ModelTires
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
    }

    public class BrandTires
    {
        public int Id { get; set; }
        public int BrandName { get; set; }
    }

    public class TiresSeason
    {
        public int Id { get; set; }
        public string Season { get; set; }
    }
}
