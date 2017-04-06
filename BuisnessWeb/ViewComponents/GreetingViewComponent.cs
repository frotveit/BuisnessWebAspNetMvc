

using BuisnessWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuisnessWeb.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        private IConfigurationGetter _greeter;
        public GreetingViewComponent(IConfigurationGetter greeter)
        {
            _greeter = greeter;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = _greeter.GetGreeting();
            return Task.FromResult<IViewComponentResult>( View("Default", model)); 
            // Must specify view name Default since model is just a string, or model will be read as view name
        }
    }
}
