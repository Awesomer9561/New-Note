using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using New_Note.Misc;
using New_Note.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace New_Note.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand Login { get; }
        public ICommand ForgotPassword { get; }
        public ICommand GoogleLogin { get; }
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
        public LoginPageViewModel()
        {
            Login = new Command(login);
            ForgotPassword = new Command(forgotPass);
            GoogleLogin = new Command(GLogin);
            SignUp = new Command(signup);
        }

        private void signup(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Pages.LoginPages.SignUpPage());
        }

        private void GLogin(object obj)
        {

        }

        private void forgotPass(object obj)
        {

        }

        private async void login(object obj)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.WebApiKey));
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

                    if (auth !=null)
                    {
                        Preferences.Set("IsLoggedIn", true);
                        Preferences.Set("Usermail", auth.User.Email);
                        //Getting notes count value

                        CheckFirebaseforUserInfo(auth.User.Email);
                        App.Current.MainPage.Navigation.PushAsync(new Pages.NotesListPage());
                    }
                    else
                    {
                        DisplayAlert("Error", "Invalid email or password");
                    }
                   
                }
                catch (System.Exception)
                {
                    DisplayAlert("Error", "Invalid email or password");
                }
            }
            else
            {
                DisplayAlert("", "Invalid Email or Password!");
            }
        }

        private async void CheckFirebaseforUserInfo(string email)
        {
            FirebaseClient client = new FirebaseClient(Constants.FirebaseDatabaseURL);
            var Users = await client.Child("Users").OnceAsync<UserModel>();

            foreach (var item in Users)
            {
                if (item.Object.Email == email)
                {
                    var user = new UserModel
                    {
                        Email = item.Object.Email,
                        Name = item.Object.Name,
                        UID = item.Object.UID,
                        Phone = item.Object.Phone,
                        Password = item.Object.Password
                    };
                    Preferences.Set("User", JsonConvert.SerializeObject(user));
                    return;
                }
            }
        }
    }
}
