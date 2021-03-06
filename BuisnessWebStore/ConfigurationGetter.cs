﻿

using Microsoft.Extensions.Configuration;

namespace BuisnessWebStore
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

        private readonly IConfiguration _configuration;
        private string _greeting;

        public string GetGreeting()
        {
            if (_greeting == null)
            {
                _greeting = _configuration["Greeting"];
            }
            return _greeting;
        }

        //public void Get()
        //{
            
        //}
    }
}
