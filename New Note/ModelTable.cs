using SQLite;

namespace New_Note
{
    public class Table2
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string Title { get; set; }
        public string NoteItem { get; set; }
        public string TimeStamp { get; set; }
        public string NoteColor { get; set; }

    }
}
