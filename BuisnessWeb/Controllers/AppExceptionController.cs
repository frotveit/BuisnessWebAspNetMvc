
using Microsoft.AspNetCore.Mvc;

namespace BuisnessWeb.Controllers
{
    public class AppExceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}