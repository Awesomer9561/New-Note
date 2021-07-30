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
        public ObservableCollection<Table2> noteItem { get; set; }
        Random r = new Random();
        public NotesListPage()
        {
            InitializeComponent();
            //CheckAndRequestStoragePermission();
        }
        public async Task<PermissionStatus> CheckAndRequestStoragePermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            return status;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            App.DatabaseLayer.Createtable();
            var notedb = App.DatabaseLayer.ReadNote().Result;
            if (notedb != null)
            {
                noteItem = new ObservableCollection<Table2>(notedb);
                noteCollectionView.ItemsSource = noteItem;
            }

            await CheckAndRequestStoragePermission();

        }

        private void search(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.SearchNotePage());
        }

        private void addNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.AddNewNote());
        }

        private void noteSelected(object sender, SelectionChangedEventArgs e)
        {
            var prevnote = e.PreviousSelection;
            var currnote = e.CurrentSelection.FirstOrDefault() as Table2;

            Navigation.PushAsync(new Pages.ViewNote(currnote));
        }

        private void profile(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Pages.ProfilePageNew());
        }
    }
}