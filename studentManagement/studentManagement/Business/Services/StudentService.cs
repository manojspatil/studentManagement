using SQLite;
using studentManagement.Business.Interfaces;
using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace studentManagement.Business.Services
{
    public class StudentService : IStudentService
    {
        private SQLiteAsyncConnection database;
        public StudentService()
        {
            database = App.Database.DataService();
        }
        public Task<List<Students>> GetStudentAsync()
        {
            return database.Table<Students>().ToListAsync();
        }

        public Task<Students> GetStudentAsync(int id)
        {
            return database.Table<Students>().Where(i => i.StudentId == id).FirstOrDefaultAsync();
        }
        public async Task<int> SaveStudentAsync(Students item)
        {
            var result = Task.Run(async () => { return await database.InsertAsync(item); }).Result;
            var test= database.Table<Students>().Where(i => i.Name == item.Name).FirstOrDefaultAsync().Id;
            return test;
        }

        public Task<int> DeleteStudentAsync(Students item)
        {
            return database.DeleteAsync(item);
        }

    }
}
