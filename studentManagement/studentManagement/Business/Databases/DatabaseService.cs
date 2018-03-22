using studentManagement.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Business.Databases
{
    public class DatabaseService
    {
        public static SQLiteAsyncConnection database;
        public DatabaseService(String dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Subject>().Wait();
            database.CreateTableAsync<Faculty>().Wait();
            database.CreateTableAsync<Students>().Wait();
            database.CreateTableAsync<SubjectNames>().Wait();

            Debug.WriteLine("Database Path: " + dbPath);
        }
        public SQLiteAsyncConnection DataService(/*String dbPath*/)
        {
            //database = new SQLiteAsyncConnection(dbPath); 
            return database;
        }


    }
}
