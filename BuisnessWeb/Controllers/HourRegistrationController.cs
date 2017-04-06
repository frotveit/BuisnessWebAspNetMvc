
using Microsoft.AspNetCore.Mvc;
using BuisnessWeb.Services;
using BuisnessWeb.Models;
using Microsoft.AspNetCore.Authorization;

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