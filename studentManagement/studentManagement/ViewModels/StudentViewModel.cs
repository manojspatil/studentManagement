using GalaSoft.MvvmLight.Command;
using studentManagement.Business.Interfaces;
using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace studentManagement.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        private IStudentService _studentService;
        private ISubjectService _subjectService;
        private RelayCommand _refreshCommand;
        private ObservableCollection<Grouping<string, Subject>> _studentMarkList;

        public StudentViewModel(IStudentService studentService, ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }

        public ObservableCollection<Grouping<string, Subject>> StudentMarkList
        {
            get { return _studentMarkList; }

            set
            {
                Set(() => StudentMarkList, ref _studentMarkList, value);
            }
        }

        public class Grouping<K, T> : ObservableCollection<T>
        {
            public K Key { get; private set; }

            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Items.Add(item);
            }
        }

        #region RelayCommands
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ??
                    (_refreshCommand = new RelayCommand(async () =>
                    {
                        try
                        {

                            var listSubject = await _subjectService.GetSubjectAsync();
                            foreach (var item in listSubject)
                            {
                                item.StudentName = (await _studentService.GetStudentAsync(item.StudentId)).Name;
                            }
                            var sorted = from lists in listSubject
                                         orderby lists.StudentName
                                         group lists by lists.StudentName into StudentSubGroup
                                         select new Grouping<string, Subject>(StudentSubGroup.Key, StudentSubGroup);

                            StudentMarkList = new ObservableCollection<Grouping<string, Subject>>(sorted);
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

        #endregion

        public override void Cleanup()
        {
            base.Cleanup();
            StudentMarkList = null;
        }
    }
}
