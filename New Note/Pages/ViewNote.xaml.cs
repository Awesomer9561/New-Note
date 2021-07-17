using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNote : ContentPage
    {
        Table2 note2 = new Table2();
        public ViewNote(Table2 note)
        {
            InitializeComponent();
            NoteViewLabel.Text = note.NoteItem;
            TitleViewLabel.Text = note.Title;
            TimeStampLabel.Text = note.TimeStamp;
            colorBox.BackgroundColor = Color.FromHex(note.NoteColor);
            note2.ID = note.ID;
        }

        private void createNote()
        {
            note2.NoteItem = NoteViewLabel.Text;
            note2.Title = TitleViewLabel.Text;
            note2.TimeStamp = DateTime.Now.ToString("d MMMM, yyyy");
            note2.NoteColor = colorBox.BackgroundColor.ToHex();
        }

        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void deleteNote(object sender, EventArgs e)
        {
            createNote();
            App.DatabaseLayer.DeleteNote(note2);
            Navigation.PopAsync();
        }

        
        private void editNote(object sender, EventArgs e)
        {
            createNote();
            Navigation.PushAsync(new EditNotePage(note2));
        }
    }
}