using System;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage : ContentPage
    {
        ObservableCollection<ModelTable> noteItem { get; set; }
        public NotesListPage()
        {
            InitializeComponent();
            App.Database.CreateNoteTable();

            OnAppearingMethod();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            OnAppearingMethod();
        }
        private void OnAppearingMethod()
        {
            var NoteDBInstance = App.Database.GetNote().Result;
            if(NoteDBInstance != null)
            {
                noteItem = new ObservableCollection<ModelTable>(NoteDBInstance);
            }
            noteCollectionView.ItemsSource = noteItem;
        }

        private void search(object sender, EventArgs e)
        {

        }

        private void addNote(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.AddNewNote());
        }

        private void noteSelected(object sender, SelectionChangedEventArgs e)
        {
            var prevnote = e.PreviousSelection;
            var currnote = e.CurrentSelection.FirstOrDefault() as ModelTable;
            
            Navigation.PushAsync(new Pages.ViewNote(currnote));
        }
    }
}