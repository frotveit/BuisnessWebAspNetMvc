

using Microsoft.Extensions.Configuration;

namespace BuisnessWeb.Services
{
    public interface IConfigurationGetter
    {
        string GetGreeting();
    }

    public class ConfigurationGetter : IConfigurationGetter
    {
        public ConfigurationGetter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration;
        private string _greeting;

        public string GetGreeting()
        {
            if (_greeting == null)
            {
                _greeting = _configuration["Greeting"];
            }
            return _greeting;
        }
    }
}
