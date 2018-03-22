using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Business.Interfaces
{
    public interface ISubjectService
    {

        Task<int> DeleteSubjectAsync(Subject item);

        Task<Subject> GetSubjectAsync(int id);

        Task<List<Subject>> GetSubjectAsync();
        void SaveSubjectListAsync(List<Subject> items);

        Task<int> SaveSubjectAsync(Subject item);

        Task<List<SubjectNames>> GetSubjectNamesAsync();
        Task<int> SaveSubjectNamesAsync(SubjectNames item);
    }

}
