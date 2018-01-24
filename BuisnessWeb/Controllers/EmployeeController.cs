using BuisnessWeb.ViewModels;
using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BuisnessWeb.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeRepository)
        {
            _employeeRepository = employeRepository;
        }

        public ViewResult SelectEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectEmployee(EmployeeIdentificator employeeIdentificator)
        {
            if ( employeeIdentificator == null)
            {
                return View();
            }
            return RedirectToAction("Employee", "Employee", new { employeeId = employeeIdentificator.EmployeeId });
        }
        
        public IActionResult Employee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            if (employee == null)
            {
                return RedirectToAction("EmployeeNotFound");
            }
            return View(employee);
        }

        public ViewResult Employees()
        {
            ViewBag.ContentMessage = "All employees.";
            EmployeesViewModel result = new EmployeesViewModel
            {
                Employees = _employeeRepository.Employees,
                CollectionTitle = "List of employees"
            };
            return View(result);
        }

        public IActionResult EnterEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnterEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.AddEmployee(employee);
                return RedirectToAction("SaveComplete", new { id = employee.EmployeeId });
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult EditEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployee(int employeeId, Employee employee)
        {
            var existingEmployee = _employeeRepository.GetEmployeeById(employeeId);
            if (existingEmployee == null)
            {
                return RedirectToAction("EmployeeNotFound");
            }

            if (ModelState.IsValid)
            {
                Update(employee, existingEmployee);
                _employeeRepository.UpdateEmployee(existingEmployee);
                return RedirectToAction("SaveComplete", new { id = employee.EmployeeId });
            }

            return View(employee);
        }

        private static void Update(Employee employee, Employee existingEmployee)
        {
            if (existingEmployee.Name != employee.Name)
                existingEmployee.Name = employee.Name;
            if (existingEmployee.Phone != employee.Phone)
                existingEmployee.Phone = employee.Phone;
            if (existingEmployee.Email != employee.Email)
                existingEmployee.Email = employee.Email;
            if (existingEmployee.Address != employee.Address)
                existingEmployee.Address = employee.Address;
            if (existingEmployee.SocialSecurityNumber != employee.SocialSecurityNumber)
                existingEmployee.SocialSecurityNumber = employee.SocialSecurityNumber;

            if (existingEmployee.PaymentInformation != null && employee.PaymentInformation != null)
            {
                if (existingEmployee.PaymentInformation.PaymentModel != employee.PaymentInformation.PaymentModel)
                    existingEmployee.PaymentInformation.PaymentModel = employee.PaymentInformation.PaymentModel;
                if (existingEmployee.PaymentInformation.PaymentFrequency != employee.PaymentInformation.PaymentFrequency)
                    existingEmployee.PaymentInformation.PaymentFrequency = employee.PaymentInformation.PaymentFrequency;
                if (existingEmployee.PaymentInformation.BankAccount != employee.PaymentInformation.BankAccount)
                    existingEmployee.PaymentInformation.BankAccount = employee.PaymentInformation.BankAccount;
            }

        }

        public IActionResult SaveComplete(int id)
        {
            ViewBag.SaveCompleteMessage = HttpContext.User.Identity.Name + ", saved";
            ViewBag.SavedEmployeeId = id;
            return View(_employeeRepository.GetEmployeeById(id));
        }

    }
}
