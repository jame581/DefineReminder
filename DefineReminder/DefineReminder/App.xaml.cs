using DefineReminder.Data;
using DefineReminder.Services;
using System;
using System.IO;
using Xamarin.Forms;

namespace DefineReminder
{
    public partial class App : Application
    {
        static EventDatabase database;

        // Create the database connection as a singleton.
        public static EventDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new EventDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EventDatabase.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
