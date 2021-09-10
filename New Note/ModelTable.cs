﻿using SQLite;

namespace New_Note
{
    public class ModelTable
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string Title { get; set; }
        public string NoteItem { get; set; }
        public string TimeStamp { get; set; }
        public string NoteColor { get; set; }

    }
}
