using Firebase.Database;
using Firebase.Database.Query;
using New_Note.Misc;
using New_Note.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace New_Note.ViewModel
{
    class NotesListPageViewModel : BaseViewModel
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
        public NotesListPageViewModel()
        {
            AddNote = new Command(addnote);
            SyncNote = new Command(syncnote);
            NoteSelectionChanged = new Command(selectionChanged);

            initData();
        }

        public async void initData()
        {
            var notedb = await App.DatabaseLayer.ReadNote();
            if (notedb != null)
            {
                NoteItem = new ObservableCollection<NotesModel>(notedb);
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
            FirebaseClient client = new FirebaseClient(Constants.FirebaseDatabaseURL);
            var results = await client.Child("Notes").OnceAsync<NotesModel>();
            var UploadedNotes = results.Select(list => list.Object).Where(item => item.Email == Constants.email).ToList();

            //notes that aren't synced
            //noteitem is offline collection and uploaded notes is online collection

            List<NotesModel> ToBeUploaded = new List<NotesModel>(noteItem);
            if (UploadedNotes.Count > 0)
            {
                foreach (var Uploaded in UploadedNotes)
                {
                    ToBeUploaded = ToBeUploaded.Select(item => item).Where(item => item.ID != Uploaded.ID).ToList();
                }
                foreach (var item in ToBeUploaded)
                {
                    await client.Child("Notes").PostAsync(item);
                }
            }
            else
            {
                foreach (var item in noteItem)
                {
                    await client.Child("Notes").PostAsync(item);
                }
            }
            await App.Current.MainPage.DisplayAlert("Success", $"Uploaded {ToBeUploaded.Count} notes", "Ok");
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
                await App.Current.MainPage.DisplayAlert("", "Please provide permission", "Ok");
                addnote(null);
            }
        }
    }
}
