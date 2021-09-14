using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note.Misc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayAlertPopup : PopupPage
    {
        bool j = true;
        public DisplayAlertPopup(string title, string content)
        {
            InitializeComponent();
            j = false;
            titleLabel.Text = title;
            contentLabel.Text = content;
        }

        private async void ErrorPopup(object sender, EventArgs e)
        {
            if (j == false)
            {
                await Frame.TranslateTo(3, 0, 50, Easing.Linear);
                await Frame.TranslateTo(-3, 0, 50, Easing.Linear);
                await Frame.TranslateTo(3, 0, 50, Easing.Linear);
                await Frame.TranslateTo(-3, 0, 50, Easing.Linear);
                await Frame.TranslateTo(0, 0, 50, Easing.Linear);
            }
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}