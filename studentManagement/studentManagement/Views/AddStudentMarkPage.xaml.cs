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
	public partial class AddStudentMarkPage : ContentPage
	{
        private AddStudentMarkViewModel _viewmodel;

        public AddStudentMarkPage ()
		{
            Title = "Add Student Marks";
            BindingContext = App.Locator.AddStudentMarkViewModel;
            _viewmodel = BindingContext as AddStudentMarkViewModel;
            InitializeComponent ();
            _saveButton.Clicked += _saveButton_Clicked;
            _subjectListView.SetBinding(ListView.ItemsSourceProperty, "SubjectList");
            
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewmodel.RefreshCommand.Execute(null);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewmodel.Cleanup();
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            _viewmodel.SaveCommand.Execute(null);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, System.EventArgs e)
        { 
            await Navigation.PopAsync();
        }
    }
}