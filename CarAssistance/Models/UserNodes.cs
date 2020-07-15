using System.Collections.Generic;

namespace CarAssistance.Models
{
    public class UserNotes
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public IList<Notes> Notes { get; set; } 
    }
}
