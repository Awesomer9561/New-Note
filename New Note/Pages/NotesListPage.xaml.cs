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
        public ObservableCollection<Table2> noteItem { get; set; }
        Random r = new Random();
        public NotesListPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.DatabaseLayer.Createtable();
            var notedb = App.DatabaseLayer.ReadNote().Result;
            if (notedb != null)
            {
                noteItem = new ObservableCollection<Table2>(notedb);
                noteCollectionView.ItemsSource = noteItem;
            }
            
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
            var currnote = e.CurrentSelection.FirstOrDefault() as Table2;

            Navigation.PushAsync(new Pages.ViewNote(currnote));
        }
    }
}