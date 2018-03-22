using Acr.UserDialogs;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using sampleapp.business;
using sampleapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace sampleapp.ViewModels
{
   public  class PatientViewModel: ViewModelBase
    {
        private IPatientService _patientService;
        private RelayCommand _refreshCommand;
        private ObservableCollection<PatientDetail> _patientDetailList;
        private PatientDetail _patientDetailObject;
        private RelayCommand<PatientDetail> _saveCommand;

        public PatientViewModel(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public ObservableCollection<PatientDetail> PatientDetailList
        {
            get { return _patientDetailList; }

            set
            {
                Set(() => PatientDetailList, ref _patientDetailList, value);
            }
        }
        public PatientDetail PatientDetailObject
        {
            get { return _patientDetailObject; }

            set
            {
                Set(() => PatientDetailObject, ref _patientDetailObject, value);
            }
        }

        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ??
                    (_refreshCommand = new RelayCommand(async () =>
                    {
                        try
                        {
                            var test = await _patientService.GetPatientList();
                            PatientDetailList = new ObservableCollection<PatientDetail>(test);
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

        public RelayCommand<PatientDetail> SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand<PatientDetail>(async (patient) =>
                    {
                        try
                        {
                            var test = await _patientService.SavePatient(patient);//.GetPatientList();
                                                                                  // PatientDetailList = new ObservableCollection<PatientDetail>(test);
                            AlertConfig alert = new AlertConfig()
                            {
                                Message = "Record Save",
                                OkText = "Ok"
                            };

                           
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
    }
}
