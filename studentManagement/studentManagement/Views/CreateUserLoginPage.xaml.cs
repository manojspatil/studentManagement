using studentManagement.Models;
using studentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace studentManagement.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateUserLoginPage : ContentPage
	{
        LoginViewModel _viewmodel;
        public CreateUserLoginPage ()
		{
            BindingContext = App.Locator.LoginViewModel;
            _viewmodel = BindingContext as LoginViewModel;
            InitializeComponent ();
            Title = "Create New User";
		}

        async void Create_Clicked(object sender, System.EventArgs e)
        {
            var personItem = (Faculty)BindingContext;
            _viewmodel.CreateFacultyCommand.Execute(personItem);
            await Navigation.PopAsync();
        }
        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
         
            await Navigation.PopAsync();
        }
    }
}