using studentManagement.Models;
using studentManagement.ViewModels;
using studentManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace studentManagement
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _viewmodel;
        public LoginPage()
        {
            BindingContext = App.Locator.LoginViewModel;
            _viewmodel = BindingContext as LoginViewModel;
            InitializeComponent();
            Title = "Login";
            _createUser.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new CreateUserLoginPage() { BindingContext = new Faculty() });
            };
            _StudentPage.Clicked += async (sender, e) =>
            {
               await Navigation.PushAsync(new StudentPage());
            }; 
        } 
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void Login_Clicked(object sender, System.EventArgs e)
        {
            if ((!string.IsNullOrEmpty(_viewmodel.UserId)) && (!string.IsNullOrEmpty(_viewmodel.Password)))
            {
                _viewmodel.LoginCommand.Execute(null);
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewmodel.Cleanup();
        }
    }
}
