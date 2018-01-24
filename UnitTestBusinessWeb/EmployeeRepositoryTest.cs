using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using BuisnessWebStore;
using BuisnessWebStore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BusinessWebTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        public IAppDbContext dbContext;

        public EmployeeRepositoryTest()
        {
            if (dbContext == null)
            {
                dbContext = InitDbContext();
            }
        }
        public IAppDbContext InitDbContext()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("dbName");
            var context = new AppDbContext(builder.Options);

            if (context.Employees.Count() == 0)
            {
                var employees = Enumerable.Range(1, 10).Select(i => new Employee { EmployeeId = i, Name = $"Name{i}", PaymentInformationId = 19 });
                context.Employees.AddRange(employees);

                var paymentInformation = new List<PaymentInformation> { new PaymentInformation { Id = 19, BankAccount = "12345" } };
                context.PaymentInformation.AddRange(paymentInformation);

                int changed = context.SaveChanges();
            }            
            return context;
        }
        
        [TestMethod]
        public void GetEmployeeById_ShouldFetchPaymentInformation()
        {
            IEmployeeRepository rep = new EmployeeRepository(dbContext);

            var employee = rep.GetEmployeeById(1);
            Assert.AreEqual(1, employee.EmployeeId);
            Assert.AreEqual("Name1", employee.Name);
            Assert.AreEqual("12345", employee.PaymentInformation.BankAccount);
        }
    }
}
