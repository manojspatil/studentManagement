using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Business.Interfaces
{
    public interface IStudentService
    {  
        Task<int> DeleteStudentAsync(Students item);
        
        Task<Students> GetStudentAsync(int id);
        
        Task<List<Students>> GetStudentAsync();

        Task<int> SaveStudentAsync(Students item);
    }
}
