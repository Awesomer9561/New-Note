using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNote : ContentPage
    {
        public ViewNote(ModelTable note)
        {
            InitializeComponent();
            NoteViewLabel.Text = note.NoteItem;
            TitleViewLabel.Text = note.Title;
            TimeStampLabel.Text = note.TimeStamp;
            colorBox.BackgroundColor = note.NoteColor;
        }

        private void back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void deleteNote(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var note = button.BindingContext as ModelTable;

            App.Database.DeleteNote(note);
            Navigation.PopAsync();
        }


        private void editNote(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var note = button.BindingContext as ModelTable;
            Navigation.PushAsync(new EditNotePage(note));
        }
    }
}