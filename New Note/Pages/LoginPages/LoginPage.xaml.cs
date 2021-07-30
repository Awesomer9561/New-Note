using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Pages.LoginPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void forgotpassword(object sender, EventArgs e)
        {

        }

        private void signup(object sender, EventArgs e)
        {

        }

        private void login(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Pages.NotesListPage());
        }

        private void googleLogin(object sender, EventArgs e)
        {

        }
    }
}