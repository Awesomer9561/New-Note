using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note
{
    public partial class App : Application
    {
        public static LocalDatabase database;
        public static LocalDatabase DatabaseLayer
        {
            get
            {
                if (database == null)
                {
                    database = new LocalDatabase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DatabaseLayer.Createtable();
            //string UserUID = "";

            MainPage = new NavigationPage(new Pages.NotesListPage());
            //MainPage = new NavigationPage(new Pages.ProfilePage());
            //MainPage = new NavigationPage(new Pages.LoginPages.LoginPage());
            //MainPage = new NavigationPage(new Pages.LoginPages.SignUpPage());
            //MainPage = new NavigationPage(new Pages.SearchNotePage());
            //MainPage = new NavigationPage(new Pages.AddNewNote());
            //MainPage = new NavigationPage(new Misc.DisplayAlertPopup());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
