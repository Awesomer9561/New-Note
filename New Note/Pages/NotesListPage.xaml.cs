using New_Note.Models;
using New_Note.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage : ContentPage
    {
        public NotesListPageViewModel viewmodel;
        public NotesListPage()
        {
            InitializeComponent();
            viewmodel = new NotesListPageViewModel();
        //CheckAndRequestStoragePermission();
    }
    protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.initData();
            this.BindingContext = viewmodel;
        }
        private void search(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SearchNotePage());
        }

        private void addNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.AddNewNote());
        }
    }
}