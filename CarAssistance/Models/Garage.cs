using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarAssistance.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int AccountId { get; set; }
        public int UserNotesId { get; set; }

        [Timestamp]
        public DateTime DateRegister { get; set; }

        public Account Account { get; set; }
        public IList<Car> Cars { get; set; }
        public IList<UserNotes> UserNotes { get; set; }

    }
}
