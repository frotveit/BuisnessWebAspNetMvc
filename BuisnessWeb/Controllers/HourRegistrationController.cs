
using BuisnessWebCore.Models;
using BuisnessWebCore.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuisnessWeb.Controllers
{
    [Authorize]
    public class HourRegistrationController : Controller
    {
        private readonly IHourRegistrationRepository _hourRegistration;

        public HourRegistrationController(IHourRegistrationRepository hourRegistration)
        {
            _hourRegistration = hourRegistration;
        }

        public IActionResult EnterHourRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnterHourRegistration(HourRegistration hourRegistration)
        {
            if (ModelState.IsValid)
            {
                _hourRegistration.AddHourRegistration(hourRegistration);
                return RedirectToAction("Save complete");
            }
            return View(hourRegistration);
        }
    }
}