using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace New_Note.Models
{
    public class NotesModel
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string Title { get; set; }
        public string NoteItem { get; set; }
        public string TimeStamp { get; set; }
        public string NoteColor { get; set; }
        public string Email { get; set; }
        public bool IsSynced { get; set; }
    }
}
