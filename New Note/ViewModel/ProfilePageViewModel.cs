using New_Note.Misc;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace New_Note.ViewModel
{
    class ProfilePageViewModel : BaseViewModel
    {
        public string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChange("Email");
            }
        }
        public string notesCount;
        public string NotesCount
        {
            get { return notesCount; }
            set
            {
                notesCount = value;
                OnPropertyChange("NotesCount");
            }
        }

        public string initials;
        public string Initials
        {
            get { return initials; }
            set
            {
                initials = value;
                OnPropertyChange("Initials");
            }
        }
        public ICommand Logout { get; }
        public ProfilePageViewModel()
        {
            setProfileInfo();
            Logout = new Command(logout);
        }

        private void setProfileInfo()
        {
            NotesCount = Constants.NotesCount;
            Email = Constants.User.Email;
            string[] nameSplit = (Constants.User.Name).Trim().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            var initials = nameSplit[0].Substring(0, 1).ToUpper();

            if (nameSplit.Length > 1)
            {
                initials += nameSplit[nameSplit.Length - 1].Substring(0, 1).ToUpper();
            }

            Initials = initials;
        }

        private void logout(object obj)
        {
            Preferences.Set("IsLoggedIn", false);
            Constants.User = null;
            App.Current.MainPage = new NavigationPage(new Pages.NotesListPage());
        }
    }
}
