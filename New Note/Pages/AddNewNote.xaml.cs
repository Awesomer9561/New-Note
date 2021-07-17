using System;
using Xamarin.CommunityToolkit.Extensions;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //TitleEntry.Focus();

        }
        readonly Random r = new Random();
        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void saveNote(object sender, EventArgs e)
        {
            string title = TitleEntry.Text;
            string note = NoteEditor.Text;
            string timeStamp = DateTime.Now.ToString("ddd d MMMM, yyyy");
            string bgColor = Color.FromHsv(r.Next(0,250) , 70 , 89 ).ToHex();

            //if not empty
            if (string.IsNullOrEmpty(title)|| string.IsNullOrEmpty(note) == false)
            {
                Table2 noteItem = new Table2()
                {
                    Title = title,
                    NoteItem = note,
                    TimeStamp = timeStamp,
                    NoteColor = bgColor
                };

                App.DatabaseLayer.SaveNote(noteItem);
                Application.Current.MainPage.DisplayToastAsync("Item Added Successfully");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please Write Something", "Ok");
            }
        }

        private void titleCompleted(object sender, EventArgs e)
        {
            NoteEditor.Focus();
        }
    }
}