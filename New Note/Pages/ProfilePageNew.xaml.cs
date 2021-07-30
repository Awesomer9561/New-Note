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
    public partial class ProfilePageNew : ContentPage
    {
        public ProfilePageNew()
        {
            InitializeComponent();
        }

        private void logout(object sender, EventArgs e)
        {
            App.Current.MainPage = new Pages.LoginPages.LoginPage();
        }
    }
}