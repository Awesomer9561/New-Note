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
    public partial class DisplayAlertPopup : PopupPage
    {
        bool j = true;
        public DisplayAlertPopup(bool i)
        {
            InitializeComponent();
            if (i == false)
            {
                j = false;
                titleLabel.Text = "Error";
                contentLabel.Text = "Please write something";
                okLabel.Text = "Ok";
            }
            else
            {
                titleLabel.Text = "Succcess";
                contentLabel.Text = "Note added successfully";
                okLabel.Text = "Ok";
                PopupFrame.CloseWhenBackgroundIsClicked = true;

                //PopupNavigation.PopAsync();
            }
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