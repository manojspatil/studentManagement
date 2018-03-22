using studentManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace studentManagement.Business.Interfaces
{
    public interface IFacultyService
    {
     
        Task<Faculty> GetFacultyAsync(int id);
        Task<Faculty> GetFacultyAsync(string userName, string Password); 
        Task<List<Faculty>> GetFacultyAsync(); 
        Task<int> SaveFacultyAsync(Faculty item);
    }
}
