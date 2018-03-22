using SQLite;
using studentManagement.Business.Interfaces;
using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Business.Services
{
    public class SubjectService : ISubjectService
    {
        private SQLiteAsyncConnection database;
        public SubjectService()
        {
            database = App.Database.DataService();
        }
        public Task<List<Subject>> GetSubjectAsync()
        {
            return database.Table<Subject>().ToListAsync();
        }


        public Task<Subject> GetSubjectAsync(int id)
        {
            return database.Table<Subject>().Where(i => i.SubjectId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveSubjectAsync(Subject item)
        {
            if (item.SubjectId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public void SaveSubjectListAsync(List<Subject> items)
        {
            try
            {
                foreach (var item in items)
                {
                    var saveid = database.InsertAsync(item);
                }
            }
            catch (Exception)
            {
            }

        }
        public Task<int> DeleteSubjectAsync(Subject item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<SubjectNames>> GetSubjectNamesAsync()
        {
            return database.Table<SubjectNames>().ToListAsync();
        }


        public Task<int> SaveSubjectNamesAsync(SubjectNames item)
        {
            if (item.SubjectId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }


    }
}

