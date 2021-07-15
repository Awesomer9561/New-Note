using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewNote : ContentPage
    {
        public AddNewNote()
        {
            InitializeComponent();
        }
        Random r = new Random();
        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void saveNote(object sender, EventArgs e)
        {
            string title = TitleEntry.Text;
            string note = NoteEditor.Text;
            string timeStamp = DateTime.Now.ToString("d MMMM, yyyy");
            var bgcolor = Color.FromRgba(r.Next(100, 256), r.Next(100, 256), r.Next(100, 256), 200);

            //if not empty
            if (string.IsNullOrEmpty(title)|| string.IsNullOrEmpty(note) == false)
            {
                ModelTable noteItem = new ModelTable()
                {
                    Title = title,
                    NoteItem = note,
                    TimeStamp = timeStamp,
                    NoteColor = bgcolor
                };

                App.Database.SaveNote(noteItem);

                await DisplayAlert("Success", "Item Added Successfully", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please Write Something", "Ok");
            }
        }
    }
}