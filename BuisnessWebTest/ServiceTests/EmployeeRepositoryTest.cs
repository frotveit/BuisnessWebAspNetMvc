
using BuisnessWeb.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuisnessWebTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        [TestMethod]
        public void GetEmployeeByIdShouldFetchEmployee()
        {
            AppDbContext context = new AppDbContext(new DbContextOptions<AppDbContext>());
            IEmployeeRepository repository = new EmployeeRepository(context);

            var employee = repository.GetEmployeeById(1);
        }
    }
}
