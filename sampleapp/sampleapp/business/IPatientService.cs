using sampleapp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sampleapp.business
{
    public interface IPatientService
    {
        Task<List<PatientDetail>> GetPatientList();
        Task<int> SavePatient(PatientDetail item);

    }
}
