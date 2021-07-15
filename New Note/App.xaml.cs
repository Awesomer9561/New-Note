using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Note
{
    public partial class App : Application
    {
        public static DatabaseLayer database;
        public static DatabaseLayer Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseLayer();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.NotesListPage());
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
