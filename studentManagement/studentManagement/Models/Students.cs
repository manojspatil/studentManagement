using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace studentManagement.Models
{ 
   public class Students
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; } 
        public string Name { get; set; }  
      // public List<Subject> StudentSubject { get; set; }


    }
}
