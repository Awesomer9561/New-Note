using New_Note.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchNotePage : ContentPage
    {
        List<NotesModel> notes = App.DatabaseLayer.ReadNote().Result;
        ObservableCollection<NotesModel> notesCollection { get; set; }

        public SearchNotePage()
        {
            InitializeComponent();
            notesCollection = new ObservableCollection<NotesModel>(notes);
            suggestionsListView.ItemsSource = notesCollection;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = NoteSearchBar.Text;
            var suggestions = notesCollection.Where(c => c.Title.ToLower().Contains(keyword.ToLower()));

            suggestionsListView.ItemsSource = suggestions;
        }

        private void NoteSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = NoteSearchBar.Text;
            var noteItem = notesCollection.Where(c => c.Title.ToLower().Contains(keyword.ToLower()));

            suggestionsListView.ItemsSource = noteItem;
        }
        public void GotoNote(NotesModel note)
        {
            if (note != null)
            {
                App.Current.MainPage.Navigation.PushAsync(new ViewNote(note));
            }
        }

        private void suggestionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prev = e.PreviousSelection;
            var curr = e.CurrentSelection as NotesModel;
            GotoNote(curr);
        }

        private void noteSelected(object sender, SelectionChangedEventArgs e)
        {
            var prev = e.PreviousSelection;
            var curr = e.CurrentSelection.FirstOrDefault() as NotesModel;
            GotoNote(curr);
        }

        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void activateFrame(object sender, EventArgs e)
        {
            NoteSearchBar.Focus();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NoteSearchBar.Focus();
        }
    }
}