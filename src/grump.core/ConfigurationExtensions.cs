using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Grump.Core
{
    public static class ConfigurationExtensions
    {
        public static void ShouldContainConfigurationKey(this IConfiguration configuration, string key)
        {
            //configuration.FirstOrDefault(key);
        }

        public static bool ContainsConfigurationKey(this IConfiguration configuration, string key)
        {
            throw new NotImplementedException();
        }



    }
}
