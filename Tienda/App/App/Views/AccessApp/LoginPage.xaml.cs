using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views.AccessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private HomeUser homeUser;

        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(HomeUser homeUser)
        {
            this.homeUser = homeUser;
        }
    }
}