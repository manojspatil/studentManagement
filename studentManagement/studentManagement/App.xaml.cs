using studentManagement.Business.Databases;
using studentManagement.Business.Interfaces;
using studentManagement.Models;
using studentManagement.ViewModels;
using studentManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace studentManagement
{
	public partial class App : Application
	{
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? new ViewModelLocator();
        static DatabaseService database;
        public static Faculty LoginInUser { get; set; }

        public App ()
		{
			InitializeComponent();
            App.Current.MainPage = new NavigationPage(new LoginPage());
          //  App.Current.MainPage = new NavigationPage(new CreateUserLoginPage());

        }

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseService(DependencyService.Get<ILocalFileHelper>().GetAsyncConnection());
                }

                return database;
            }
        }
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
