using New_Note.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNotePage : ContentPage
    {
        readonly int id;
        public EditNotePage(NotesModel note)
        {
            InitializeComponent();
            id = note.ID;
            NoteViewLabel.Text = note.NoteItem;
            TitleViewLabel.Text = note.Title;
            TimeStampLabel.Text = note.TimeStamp;
            colorBox.BackgroundColor = Color.FromHex(note.NoteColor);
        }

        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void saveNote(object sender, EventArgs e)
        {
            NotesModel note = new NotesModel();
            note.ID = id;
            note.NoteItem = NoteViewLabel.Text;
            note.Title = TitleViewLabel.Text;
            note.TimeStamp = DateTime.Now.ToString("d MMMM, yyyy");
            note.NoteColor = colorBox.BackgroundColor.ToHex();

            App.DatabaseLayer.SaveNote(note);

            await Navigation.PopToRootAsync();
        }
    }
}