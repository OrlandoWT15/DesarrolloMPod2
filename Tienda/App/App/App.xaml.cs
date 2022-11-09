using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Views.AccessApp;

namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage(new HomeUser());
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
