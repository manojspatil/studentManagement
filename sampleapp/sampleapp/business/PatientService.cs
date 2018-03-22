using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sampleapp.Models;
using SQLite;

namespace sampleapp.business
{
    public class PatientService : IPatientService
    {
        SQLiteAsyncConnection database;
        public PatientService()
        {
            database = App.Database.DataService();
        }
        public Task<List<PatientDetail>> GetPatientList()
        {
            return database.Table<PatientDetail>().ToListAsync();
        }

        public Task<int> SavePatient(PatientDetail item)
        {
            if (item.ID != 0)
            {
                //code for update
                return database.UpdateAsync(item);
            }
            else
            {
                //code for insert
                return database.InsertAsync(item);
            }
        }
    }
}
