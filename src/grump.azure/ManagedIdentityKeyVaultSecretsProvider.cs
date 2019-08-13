using System.Threading.Tasks;
using Grump.Core;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace Grump.Azure
{
    public class ManagedIdentityKeyVaultSecretsProvider : ISecretsProvider
    {
        public async Task<string> GetSecretAsync(string secretName)
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVaultClient.GetSecretAsync("").ConfigureAwait(false);

            return secret.Value;
        }
    }
}
