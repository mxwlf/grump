using Microsoft.Extensions.Configuration;

namespace Grump.ValidationExtensions
{
    public static class ConfigurationValidationExtensions
    {
        public static ConfigurationValidationDefinition Should(this IConfiguration configuration)
        {
            var builder = new ConfigurationValidationDefinition(configuration);

            return new ConfigurationValidationDefinition(builder);

        }
    }
}
