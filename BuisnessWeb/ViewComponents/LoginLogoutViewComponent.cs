

using Microsoft.AspNetCore.Mvc;

namespace BuisnessWeb.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
