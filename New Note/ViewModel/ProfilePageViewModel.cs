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
        public string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChange("Password");
            }
        }

        public string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChange("Username");
            }
        }
    }
}
