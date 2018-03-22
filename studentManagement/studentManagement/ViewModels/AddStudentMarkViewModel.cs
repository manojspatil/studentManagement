using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using studentManagement.Business.Interfaces;
using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace studentManagement.ViewModels
{
   public class AddStudentMarkViewModel:BaseViewModel
    {
        private IStudentService _studentService;
        private ISubjectService _subjectService;
        private RelayCommand _refreshCommand;
        private RelayCommand _saveCommand;
        private ObservableCollection<Subject> _subjectList;
        private string _studentName;
        private RelayCommand<String> _saveSubjectsCommand;

        public List<string> ListSubject { get; set; }

        public AddStudentMarkViewModel(IStudentService studentService,ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }
        public string StudentName
        {
            get { return _studentName; }

            set
            {
                Set(() => StudentName, ref _studentName, value);
            }
        }
        public ObservableCollection<Subject> SubjectList
        {
            get { return _subjectList; }

            set
            {
                Set(() => SubjectList, ref _subjectList, value);
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
                            ListSubject = new List<string> { "English", "Maths", "Science" };

                            var test = (await _subjectService.GetSubjectNamesAsync());
                            if (test.Count >= 0)
                            { 
                                ListSubject.AddRange(test.Select(x => x.SubjectName).ToList());  
                            }

                            List<Subject> tempList = new List<Subject>();
                            foreach (var item in ListSubject)
                            {
                                tempList.Add(new Subject() { SubjectName = item });
                            }
                            SubjectList= new ObservableCollection<Subject>(tempList);

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
       
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(async () =>
                    {
                        try
                        {
                            var studentId = Task.Run(async () => { return await _studentService.SaveStudentAsync(new Students() { Name = StudentName }); }).Result;
                           // var studentId = await _studentService.SaveStudentAsync(new Students() { Name = StudentName});

                            foreach (var item in SubjectList)
                                {
                                    item.StudentId = studentId;
                                }
                                _subjectService.SaveSubjectListAsync(new List<Subject>(SubjectList)); 
                            AlertConfig alert = new AlertConfig
                            {
                                Message = "Student Marks Added Succssfuly.",
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

        public RelayCommand<String> SaveSubjectsCommand
        {
            get
            {
                return _saveSubjectsCommand ??
                    (_saveSubjectsCommand = new RelayCommand<String>(async (subject) =>
                    {
                        try
                        {
                           await _subjectService.SaveSubjectNamesAsync(new SubjectNames() { SubjectName = subject });
                            AlertConfig alert = new AlertConfig
                            {
                                Message = "Subject Added Succssfuly.",
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
            StudentName = string.Empty;
            SubjectList = null;
        }
    }
}
