using System;
using System.Collections.Generic;


namespace CarAssistance.Models
{
    public class Garage
    {
        public int GarageId { get; set; }
        public List<Car> Car { get; set; }
        public string NameUser { get; set; }
        public string UserPassword { get; set; }
        public DateTime DateRegister { get; set; }
        public string Note { get; set; }
    }
}
