using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAssistance.Models
{
    public class OilInfo
    {
        public int Id { get; set; }
        public string OilName { get; set; }
        public string OilModel { get; set; }
        public string OilViscosity_SAE { get; set; }
        public string OilTempeature_SAE { get; set; }
        public int FuelId { get; set; }
        public string OilType { get; set; }
        public double OilVolume { get; set; }
        public string SpecificationOem { get; set; }
        public string SpecificationAcea { get; set; }
        public string SpecificationApi { get; set; }
    }
}
