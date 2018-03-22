using sampleapp.Models;
using sampleapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sampleapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PatientListPage : ContentPage
	{
        PatientViewModel _viewModel;
        private ToolbarItem toolbaritem;

        public PatientListPage ()
		{
            BindingContext = App.Locator.PatientViewModel;
            _viewModel = BindingContext as PatientViewModel;
            InitializeComponent();
            Title = "Patient List";
            toolbaritem = new ToolbarItem
            {
                Name="Add Patient"
            };
            toolbaritem.Clicked += async(sender, e) =>
            {
               await Navigation.PushAsync(new PatientPage() { BindingContext = new PatientDetail() });
            };
            ToolbarItems.Add(toolbaritem);
            patientListView.SetBinding(ListView.ItemsSourceProperty, "PatientDetailList");
            patientListView.ItemSelected += PatientListView_ItemSelected;
            BackgroundColor = Color.LightCyan;
        }

        private async void PatientListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PatientPage() { BindingContext = e.SelectedItem as PatientDetail });
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.RefreshCommand.Execute(null);
        }

        
    }
}