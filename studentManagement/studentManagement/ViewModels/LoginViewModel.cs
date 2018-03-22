using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using studentManagement.Business.Interfaces;
using studentManagement.Models;
using studentManagement.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace studentManagement.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private IFacultyService _facultyService; 
        private RelayCommand<Faculty> _createFacultyCommand;
        private string _userId;
        private string _password;
        private RelayCommand _loginCommand;
       
        public LoginViewModel(IFacultyService ifacultyserv)
        {
            _facultyService = ifacultyserv;
        }

        public string UserId
        {
            get { return _userId; }
            set
            {
                Set(() => UserId, ref _userId, value);
            }
        }
        public string Password
        {
            get { return _password; }

            set
            {
                Set(() => UserId, ref _password, value);
            }
        }


        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                    (_loginCommand = new RelayCommand(async () =>
                    {
                        try
                        {
                            var test = await _facultyService.GetFacultyAsync(UserId, Password);
                            if (test != null)
                            {
                                AlertConfig alert = new AlertConfig
                                {
                                    Message = "Login Succssfuly.",
                                    OkText = "Ok"
                                };
                                UserDialogs.Instance.Alert(alert);
                                App.LoginInUser = test;
                                App.Current.MainPage = new NavigationPage(new MainPage());
                            }
                            else
                            {
                                AlertConfig alert = new AlertConfig
                                {
                                    Message = "Login Failed.",
                                    OkText = "Ok"
                                };
                                UserDialogs.Instance.Alert(alert);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                        }

                    }));
            }
        }

        public RelayCommand<Faculty> CreateFacultyCommand
        {
            get
            {
                return _createFacultyCommand ??
                    (_createFacultyCommand = new RelayCommand<Faculty>(async (emp) =>
                    {
                        try
                        {

                            var test = await _facultyService.SaveFacultyAsync(emp);

                            AlertConfig alert = new AlertConfig
                            {
                                Message = "User Created Succssfuly.",
                                OkText = "Ok"
                            };
                            UserDialogs.Instance.Alert(alert);
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                        }
                    }));
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();
            UserId ="";
            Password ="";
        }
    }
}
