using New_Note.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNote : ContentPage
    {
        NotesModel noteItem = new NotesModel();
        public ViewNote(NotesModel note)
        {
            InitializeComponent();
            noteItem = note;

            OnAppearing();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            NoteViewLabel.Text = noteItem.NoteItem;
            TitleViewLabel.Text = noteItem.Title;
            TimeStampLabel.Text = noteItem.TimeStamp;
            colorBox.BackgroundColor = Color.FromHex(noteItem.NoteColor);
        }

        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void deleteNote(object sender, EventArgs e)
        {
            App.DatabaseLayer.DeleteNote(noteItem);
            Navigation.PopAsync();
        }

        
        private void editNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditNotePage(noteItem));
        }
    }
}