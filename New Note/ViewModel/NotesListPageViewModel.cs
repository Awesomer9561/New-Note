using Firebase.Database;
using Firebase.Database.Query;
using New_Note.Misc;
using New_Note.Models;
using New_Note.Pages;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace New_Note.ViewModel
{
    public class NotesListPageViewModel : BaseViewModel
    {
        public NotesModel SelectedNote { get; set; }
        public ObservableCollection<NotesModel> noteItem;
        public ObservableCollection<NotesModel> NoteItem
        {
            get { return noteItem; }
            set
            {
                noteItem = value;
                OnPropertyChange("NoteItem");
            }
        }
        public ICommand AddNote { get; }
        public ICommand SyncNote { get; }
        public ICommand NoteSelectionChanged { get; }
        public ICommand GotoProfile { get; }
        public NotesListPageViewModel()
        {
            AddNote = new Command(addnote);
            SyncNote = new Command(syncnote);
            GotoProfile = new Command(gotoprofile);
            NoteSelectionChanged = new Command(selectionChanged);

            initData();
        }

        private void gotoprofile(object obj)
        {
            if (Constants.IsLoggedIn)
            {
                App.Current.MainPage.Navigation.PushModalAsync(new ProfilePage());
            }
            else
            {
                DisplayPrompt("Login required!", "You need to login to unlock this feature");
            }
        }

        public async void initData()
        {

            var notedb = await App.DatabaseLayer.ReadNote();
            if (notedb != null)
            {
                NoteItem = new ObservableCollection<NotesModel>(notedb);
                Constants.NotesCount = NoteItem.Count.ToString();
            }
        }

        private void selectionChanged(object obj)
        {
            if (SelectedNote == null)
            {
                return;
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new Pages.ViewNote(SelectedNote));
                SelectedNote = null;
            }
        }

        private async void syncnote(object obj)
        {
            if (Preferences.Get("IsLoggedIn", false))
            {
                FirebaseClient client = new FirebaseClient(Constants.FirebaseDatabaseURL);
                
                List<NotesModel> ToBeUploaded = new List<NotesModel>();
                ToBeUploaded = noteItem.Select(item => item).Where(item => item.IsSynced == false).ToList();
                foreach (var item in ToBeUploaded)
                {
                    await client.Child("Notes").PostAsync(item);
                    item.IsSynced = true;
                    App.DatabaseLayer.SaveNote(item);
                }
                DisplayAlert("Sucess", $"Uploaded {ToBeUploaded.Count} notes");
            }
            else
            {
                PopupNavigation.PushAsync(new DisplayPromptPopup("Login Required!", "Please login to avail and use this feature"));
            }
        }



        private async void addnote(object obj)
        {
            var status = await Constants.CheckAndRequestStoragePermission();
            if (status == PermissionStatus.Granted)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Pages.AddNewNote());
            }
            else
            {
                DisplayAlert("", "Please provide permissions");
                addnote(null);
            }
        }
    }
}
