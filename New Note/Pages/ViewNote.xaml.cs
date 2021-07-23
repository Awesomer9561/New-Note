using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNote : ContentPage
    {
        Table2 note2 = new Table2();
        Table2 note1 = new Table2();
        public ViewNote(Table2 note)
        {
            InitializeComponent();
            note1 = note;
            note2 = note;

            OnAppearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            NoteViewLabel.Text = note1.NoteItem;
            TitleViewLabel.Text = note1.Title;
            TimeStampLabel.Text = note1.TimeStamp;
            colorBox.BackgroundColor = Color.FromHex(note1.NoteColor);
        }

        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void deleteNote(object sender, EventArgs e)
        {
            App.DatabaseLayer.DeleteNote(note2);
            Navigation.PopAsync();
        }

        
        private void editNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditNotePage(note2));
        }
    }
}