using System;

namespace CarAssistance.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
        public Manufacters Manufacters { get; set; }
    }
}
