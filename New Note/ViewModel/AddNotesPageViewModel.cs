using Firebase.Database;
using Firebase.Database.Query;
using New_Note.Misc;
using New_Note.Models;
using System;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace New_Note.ViewModel
{
    public class AddNotesPageViewModel : BaseViewModel
    {
        public Random r = new Random();
        public FirebaseClient client = new FirebaseClient(Constants.FirebaseDatabaseURL);

        public ICommand SaveNote { get; }
        public string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChange("Title");
            }
        }
        public string note;
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChange("Note");
            }
        }

        public AddNotesPageViewModel()
        {
            SaveNote = new Command(savenote);
        }

        private void savenote(object obj)
        {
            if (!string.IsNullOrEmpty(Note) && !string.IsNullOrEmpty(Title))
            {
                SaveNotewithEmail();
            }
        }

        //Saving the note in local database
        public void SaveNotewithEmail()
        {
            string Timestamp = DateTime.Now.ToString("ddd, d MMM yyyy");
            string Color = Constants.setColors();
            string email = Constants.email;
            if (!string.IsNullOrEmpty(email))
            {
                NotesModel noteItem = new NotesModel()
                {
                    Email = email,
                    NoteColor = Color,
                    NoteItem = Note,
                    Title = Title,
                    TimeStamp = Timestamp
                };

                App.DatabaseLayer.SaveNote(noteItem);
                //client.Child("Notes").PostAsync(noteItem);

                Application.Current.MainPage.DisplayToastAsync("Item Added Successfully");
                App.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}