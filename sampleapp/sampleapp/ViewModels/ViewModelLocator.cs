using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using sampleapp.business;
using System;
using System.Collections.Generic;
using System.Text;

namespace sampleapp.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IPatientService, PatientService>();

            SimpleIoc.Default.Register<PatientViewModel>();
        }
        public PatientViewModel PatientViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<PatientViewModel>())
                {
                    SimpleIoc.Default.Register<PatientViewModel>();
                }
                return ServiceLocator.Current.GetInstance<PatientViewModel>();
            }
        }

    }
}
