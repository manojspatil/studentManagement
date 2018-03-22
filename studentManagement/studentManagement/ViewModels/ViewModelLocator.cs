using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using studentManagement.Business.Interfaces;
using studentManagement.Business.Services;

namespace studentManagement.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IFacultyService, FacultyService>();
            SimpleIoc.Default.Register<IStudentService, StudentService>();
            SimpleIoc.Default.Register<ISubjectService, SubjectService>();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<StudentViewModel>();
            SimpleIoc.Default.Register<AddStudentMarkViewModel>();
        }


        public LoginViewModel LoginViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<LoginViewModel>())
                {
                    SimpleIoc.Default.Register<LoginViewModel>();
                }
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }


        public StudentViewModel StudentViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<StudentViewModel>())
                {
                    SimpleIoc.Default.Register<StudentViewModel>();
                }
                return ServiceLocator.Current.GetInstance<StudentViewModel>();
            }
        }

        public AddStudentMarkViewModel AddStudentMarkViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<AddStudentMarkViewModel>())
                {
                    SimpleIoc.Default.Register<AddStudentMarkViewModel>();
                }
                return ServiceLocator.Current.GetInstance<AddStudentMarkViewModel>();
            }
        }
    }
}
