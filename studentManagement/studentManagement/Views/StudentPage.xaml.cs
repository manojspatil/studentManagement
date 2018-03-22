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
    public partial class StudentPage : ContentPage
    {
        private StudentViewModel _viewmodel;

        public StudentPage()
        {
            BindingContext = App.Locator.StudentViewModel;
            _viewmodel = BindingContext as StudentViewModel;
            InitializeComponent();
            Title = "Student Mark List";
            _StudentMarkListView.SetBinding(ListView.ItemsSourceProperty, "StudentMarkList"); 
            _StudentMarkListView.IsGroupingEnabled = true;
          //  _StudentMarkListView.GroupDisplayBinding = new Binding("Key"); //this is our key property on grouping.
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
    }
}