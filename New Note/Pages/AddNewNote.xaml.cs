using Rg.Plugins.Popup.Services;
using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewNote : ContentPage
    {
        string[] colors = new string[20];
        public AddNewNote()
        {
            InitializeComponent();
            setColors();
        }

        private void setColors()
        {
            colors[0] = "#eccc68";
            colors[1] = "#ff7f50";
            colors[2] = "#ff6b81";
            colors[3] = "#7bed9f";
            colors[4] = "#70a1ff";
            colors[5] = "#5352ed";
            colors[6] = "#1e90ff";
            colors[7] = "#2ed573";
            colors[8] = "#2d98da";
            colors[9] = "#a55eea";
            colors[10] = "#3867d6";
            colors[11] = "#34e7e4";
            colors[12] = "#0fbcf9";
            colors[13] = "#ff3f34";
            colors[14] = "#F8EFBA";
            colors[15] = "#F97F51";
            colors[16] = "#55E6C1";
            colors[17] = "#D6A2E8";
            colors[18] = "#55E6C1";
            colors[19] = "#25CCF7";
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
            //string bgColor = Color.FromHsv(r.Next(0,250) , 70 , 89 ).ToHex();
            string bgColor = colors[r.Next(0, 19)];
            //if not empty
            if (string.IsNullOrEmpty(title)== false || string.IsNullOrEmpty(note) == false)
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
                //await PopupNavigation.PushAsync(new Misc.DisplayAlertPopup(true));
                await Navigation.PopAsync();
            }
            else
            {
                await PopupNavigation.PushAsync(new Misc.DisplayAlertPopup(false));
                //await App.Current.MainPage.DisplayAlert("Error", "Please Write Something","Ok");
            }
        }
        private void titleCompleted(object sender, EventArgs e)
        {
            NoteEditor.Focus();
        }
    }
}