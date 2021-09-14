using New_Note.Pages.LoginPages;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Misc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayPromptPopup : PopupPage
    {
        public DisplayPromptPopup(string title, string content)
        {
            InitializeComponent();
            titleLabel.Text = "Login required!";
            contentLabel.Text = "Please to enable and use this feature";
        }

        private void cancel(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }

        private void login(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}