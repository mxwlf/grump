using System;
using System.Threading.Tasks;
using Grump.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Grump.Azure
{
    public class ManagedIdentityKeyVaultSecretsProvider : ISecretsProvider
    {
        private readonly IConfigurationProvider _configurationProvider;

        public ManagedIdentityKeyVaultSecretsProvider(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider ?? throw new ArgumentNullException("configurationProvider");
        }
        public async Task<string> GetSecretAsync(string secretName)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
