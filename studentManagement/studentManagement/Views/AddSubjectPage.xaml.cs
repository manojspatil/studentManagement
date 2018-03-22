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
	public partial class AddSubjectPage : ContentPage
	{
        private AddStudentMarkViewModel _viewmodel;

        public AddSubjectPage ()
		{
            BindingContext = App.Locator.AddStudentMarkViewModel;
            _viewmodel = BindingContext as AddStudentMarkViewModel;
            InitializeComponent ();
            Title = "Add Subject";
		}
        async void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(_subject.Text))
            {
                _viewmodel.SaveSubjectsCommand.Execute(_subject.Text);
                _subject.Text = "";
                await Navigation.PopAsync();
            }
        }
    }
}