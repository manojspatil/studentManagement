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
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            Title = "Main Page";
            _LogoutButton.Clicked += async (sender, e) =>
            {
                 
                App.LoginInUser.FacultyName = null;
                App.Current.MainPage = new NavigationPage(new LoginPage());
            };
            _loginUserNameLabel.Text = App.LoginInUser.FacultyName;
            _addStudentButton.Clicked += _addStudentButton_Clicked;
            _addSubjectButton.Clicked += _addSubjectButton_Clicked;
        }

        private async void _addSubjectButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSubjectPage());
        }

        private async void _addStudentButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddStudentMarkPage());
        }
      
    }
}