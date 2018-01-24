



using BuisnessWebCore.Models;
using System.Collections.Generic;

namespace BuisnessWebCore.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
