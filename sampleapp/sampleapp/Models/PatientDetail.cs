using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace sampleapp.Models
{
    public class PatientDetail
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string PatientName { get; set; }
        public string UHID { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
    }
}
