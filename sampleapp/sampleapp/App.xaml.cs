using Acr.UserDialogs;
using GalaSoft.MvvmLight.Ioc;
using sampleapp.business;
using sampleapp.business.Database;
using sampleapp.ViewModels;
using sampleapp.Views;
using Xamarin.Forms;

namespace sampleapp
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? new ViewModelLocator();
        static DatabaseService database;
        public App()
        {
            InitializeComponent();

            // MainPage = new sampleapp.MainPage();
            SimpleIoc.Default.Register(() => UserDialogs.Instance);
             App.Current.MainPage = new NavigationPage(new PatientListPage());
            //MainPage = new PatientListPage();

        }

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseService(DependencyService.Get<ILocalFileHelper>().GetDatabaseConnection());
                }
                return database;

            }


        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
