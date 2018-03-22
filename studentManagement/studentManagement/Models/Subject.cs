using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace studentManagement.Models
{
   public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public string Marks { get; set; }
        [Ignore]
        public string StudentName { get; set; }
    }
    public class SubjectNames
    {
        [PrimaryKey, AutoIncrement]
        public int SubjectId { get; set; } 
        public string SubjectName { get; set; }
    }

}
