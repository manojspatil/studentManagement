using sampleapp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace sampleapp.business.Database
{
   public class DatabaseService
    {
        public static SQLiteAsyncConnection database;
        public DatabaseService(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<PatientDetail>();
            Debug.WriteLine(dbpath);
        }
        public SQLiteAsyncConnection DataService()
        {
            return database;
        }
    }
}
