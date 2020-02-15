
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Grump.ValidationExtensions
{
    public class ConfigurationValidationDefinition : ValidationDefinition<IConfiguration>
    {
        internal ConfigurationValidationDefinition Builder { get; private set; }

        public ConfigurationValidationDefinition(ConfigurationValidationDefinition builder) : base(builder.ValidatedSpecimen)
        {
            Builder = builder;
        }

        public ConfigurationValidationDefinition(IConfiguration validatedConfiguration) : base(validatedConfiguration)
        {

        }



        public Concatenation<ConfigurationValidationDefinition> ContainKey(string key)
        {
            key.ShouldBe().NonEmptyOrWhitespace();

            key = key.ToLowerInvariant();

            if (null == Builder.ValidatedSpecimen[key])
            {
                throw new ConfigurationErrorsException($"Missing configuration with key {key}");
            }
            return new Concatenation<ConfigurationValidationDefinition>(Builder);
        }
    }
}
