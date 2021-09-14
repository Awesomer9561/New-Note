using New_Note.Misc;
using Rg.Plugins.Popup.Services;
using System.ComponentModel;

namespace New_Note.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void DisplayPrompt(string title, string content)
        {
            PopupNavigation.PushAsync(new DisplayPromptPopup(title, content));
        }
        public void DisplayAlert(string title, string content)
        {
            PopupNavigation.PushAsync(new DisplayAlertPopup(title, content));
        }
    }
}