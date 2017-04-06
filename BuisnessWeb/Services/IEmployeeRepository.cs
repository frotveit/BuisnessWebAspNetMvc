



using BuisnessWeb.Models;
using System.Collections.Generic;

namespace BuisnessWeb.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
