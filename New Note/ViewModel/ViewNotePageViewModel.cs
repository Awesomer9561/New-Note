using New_Note.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace New_Note.ViewModel
{
    class ViewNotePageViewModel : BaseViewModel
    {
        //public string title;
        //public string Title
        //{
        //    get { return title; }
        //    set
        //    {
        //        title = value;
        //        OnPropertyChange("Title");
        //    }
        //}
        //public string note;
        //public string Note
        //{
        //    get { return note; }
        //    set
        //    {
        //        note = value;
        //        OnPropertyChange("Note");
        //    }
        //}
        //public string color;
        //public string Color
        //{
        //    get { return color; }
        //    set
        //    {
        //        color = value;
        //        OnPropertyChange("Color");
        //    }
        //}
        //public string timeStamp;
        //public string TimeStamp
        //{
        //    get { return timeStamp; }
        //    set
        //    {
        //        timeStamp = value;
        //        OnPropertyChange("TimeStamp");
        //    }
        //}
        public ICommand DeleteNote { get; }
        public ICommand EditNote { get; }
        public ViewNotePageViewModel()
        {
            DeleteNote = new Command(deleteNote);
            EditNote = new Command(editNote);
        }
        //public void initData(NotesModel note)
        //{
        //    Color = note.NoteColor;
        //    Title = note.Title;
        //    Note = note.NoteItem;
        //    TimeStamp = note.TimeStamp;
        //}
        private void editNote(object obj)
        {

        }

        private void deleteNote(object obj)
        {

        }
    }
}
