using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note
{
    public partial class App : Application
    {
        public static Database database;
        public static Database DatabaseLayer
        {
            get
            {
                if (database == null)
                {
                    database = new Database();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DatabaseLayer.Createtable();
            //MainPage = new NavigationPage(new Pages.NotesListPage());
            //MainPage = new NavigationPage(new Pages.ProfilePageNew());
            MainPage = new NavigationPage(new Pages.LoginPages.LoginPage());
            //MainPage = new NavigationPage(new Pages.SearchNotePage());
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
