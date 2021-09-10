using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using New_Note.Misc;
using New_Note.Models;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace New_Note.ViewModel
{
    class SignUpPageViewModel : BaseViewModel
    {
        public ICommand SignUp { get; }
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
        public string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChange("Phone");
            }
        }
        public SignUpPageViewModel()
        {
            SignUp = new Command(signup);
        }

        private async void signup(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.WebApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);

                //Update Database
                FirebaseClient client = new FirebaseClient(Constants.FirebaseDatabaseURL);

                UserModel user = new UserModel()
                {
                    Email = Email,
                    Password = Password,
                    Name = Username,
                    Phone = Phone,
                };
                var result = await client.Child("Users").PostAsync(user);
                Preferences.Set("Usermail", result.Object.Email);
                // await App.Current.MainPage.DisplayAlert("", result.Key, "Ok");
            }
            catch (System.Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", ex.Message, "Ok");
            }

        }
    }
}