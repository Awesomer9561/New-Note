using SQLite;
using System;
using Xamarin.Forms;

namespace New_Note
{
    public class ModelTable
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public String Title { get; set; }
        public String NoteItem { get; set; }
        public String TimeStamp { get; set; }
        public Color NoteColor { get; set; }
    }
}
