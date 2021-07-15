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
    public partial class EditNotePage : ContentPage
    {
        public EditNotePage(ModelTable note)
        {
            InitializeComponent();
            NoteViewLabel.Text = note.NoteItem;
            TitleViewLabel.Text = note.Title;
            TimeStampLabel.Text = note.TimeStamp;
            colorBox.BackgroundColor = note.NoteColor;
        }

        private void back(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void saveNote(object sender, EventArgs e)
        {
            ModelTable note = new ModelTable();
            note.NoteItem = NoteViewLabel.Text;
            note.Title = TitleViewLabel.Text;
            note.TimeStamp = DateTime.Now.ToString();

            App.Database.SaveNote(note);
        }
    }
}