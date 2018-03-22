using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace studentManagement.Models
{
   public class Faculty
    {
        [PrimaryKey, AutoIncrement]
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
