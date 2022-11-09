using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using App.Model;
using App.ViewModel;
using System.Net;
using System.Net.Http;

namespace App.Views.AccessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage(HomeUser homeUser)
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private async void Button_Login(object sender, EventArgs e)
        {
            Login log = new Login
            {
                Usuario = txtUser.Text,
                Contrasenia = txtPasword.Text
            };
            Uri RequestUri = new Uri("");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new HomeUser());
            }

        }
    }
}