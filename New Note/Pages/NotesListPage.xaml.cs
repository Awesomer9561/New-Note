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
        NotesListPageViewModel viewmodel = new NotesListPageViewModel();
        public NotesListPage()
        {
            InitializeComponent();
            //CheckAndRequestStoragePermission();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.initData();
        }
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //NotesListPageViewModel viewmodel = new NotesListPageViewModel();
        //    ////await CheckFirebase("sss");
        //    var notedb = await App.DatabaseLayer.ReadNote();
        //    if (notedb != null)
        //    {
        //        noteItem = new ObservableCollection<NotesModel>(notedb);
        //        noteCollectionView.ItemsSource = noteItem;
        //    }

        //    //viewmodel.initData();


        //}

        //private async Task<List<NotesModel>> CheckFirebase(string email)
        //{
        //    //var = FirebaseClient.chiled.onceasync
        //    //    var.tolist.where

        //    FirebaseClient client = new FirebaseClient(Constants.FirebaseDatabaseURL);
        //    var result = await client.Child("Notes").OnceAsync<NotesModel>();
        //     var finaldat= result.Select(item => item.Object).ToList()
        //        .Where(ls => ls.Email.Equals("pali8768276167@gmail.com")).ToList();
        //    return finaldat;
        //}

        private void search(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SearchNotePage());
        }

        private void addNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.AddNewNote());
        }

        //private void noteSelected(object sender, SelectionChangedEventArgs e)
        //{
        //    var prevnote = e.PreviousSelection;
        //    var currnote = e.CurrentSelection.FirstOrDefault() as NotesModel;

        //    Navigation.PushAsync(new Pages.ViewNote(currnote));
        //}

        private void profile(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Pages.ProfilePage());
        }
    }
}