using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeaQuill
{
    public partial class App : Application
    {
        private static JokesDatabase _database;
        public static JokesDatabase Database => _database ?? (_database = new JokesDatabase());

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
