
using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessWebStore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IAppDbContext _appDbContext;

        public EmployeeRepository( IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee =  _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                employee.PaymentInformation = _appDbContext.PaymentInformation.FirstOrDefault(e => e.Id == employee.PaymentInformationId);
            }
            return employee;
        }
        
        public IEnumerable<Employee> Employees
        {
            get { return _appDbContext.Employees; }            
        }

        public void AddEmployee(Employee employee)
        {
            EntityEntry<PaymentInformation> paymentInfoResult = _appDbContext.PaymentInformation.Add(employee.PaymentInformation);
            EntityEntry<Employee> employeeResult = _appDbContext.Employees.Add(employee);
            
            int result = _appDbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _appDbContext.SaveChanges();
        }

    }

}
