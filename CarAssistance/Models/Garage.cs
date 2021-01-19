using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarAssistance.Models
{
    public class Garage
    {
        public int GarageId { get; set; }
        public List<Car> Car { get; set; }
        public Guid UserId { get; set; }
        [Timestamp]
        public DateTime DateRegister { get; set; }
        public string Note { get; set; }
        public Users User { get; set; }
    }
}
