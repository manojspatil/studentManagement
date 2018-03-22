using SQLite;
using studentManagement.Business.Interfaces;
using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Business.Services
{
    public class FacultyService : IFacultyService
    {
        private SQLiteAsyncConnection database;
        public FacultyService()
        {
            database = App.Database.DataService();
        }
        public Task<Faculty> GetFacultyAsync(int id)
        {
            return database.Table<Faculty>().Where(i => i.FacultyId == id).FirstOrDefaultAsync();
        }

        public Task<Faculty> GetFacultyAsync(string userName, string Password)
        {
            return database.Table<Faculty>().Where(i => i.UserName == userName && i.Password==Password).FirstOrDefaultAsync();
        }

        public Task<List<Faculty>> GetFacultyAsync()
        {
            return database.Table<Faculty>().ToListAsync();
        }

        public Task<int> SaveFacultyAsync(Faculty item)
        {
            if (item.FacultyId != 0)
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
