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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            TitleEntry.Focus();

        }
        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void titleCompleted(object sender, EventArgs e)
        {
            NoteEditor.Focus();
        }
    }
}