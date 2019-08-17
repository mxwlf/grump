using System;
using System.Threading.Tasks;
using Grump.Abstractions;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration;

namespace Grump.Azure
{
    public class KeyVaultSecretsProvider : ISecretsProvider
    {
        private readonly IConfiguration _configuration;

        private IKeyVaultClient _keyVaultClient;


        public KeyVaultSecretsProvider(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException("configuration");
        }

        public IKeyVaultClient KeyVaultClient
        {
            get
            {
                if (_keyVaultClient == null)
                {
                    _keyVaultClient = new ManagedIdentityKeyVaultClient();
                }

                return _keyVaultClient;
            }
        }

        public string KeyVaultUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_keyVaultUrl))
                {
                    _keyVaultUrl = GetKeyVaultUrlFromConfiguration(_configuration);
                }

                return _keyVaultUrl;
            }
        }

        private string _keyVaultUrl;


        /// <summary>
        /// Creates an new instance of the class ManagedIdentityKeyVaultSecretsProvider (Intended for testing).
        /// </summary>
        /// <param name="configurationProvider"></param>
        /// <param name="keyVaultClient"></param>
        /// <remarks>
        ///     The intention of this constructor is testing, by providing a mock IKeyVaultClient instance.
        /// </remarks>
        internal KeyVaultSecretsProvider(IConfiguration configuration, IKeyVaultClient keyVaultClient): this(configuration)
        {
            _keyVaultClient = keyVaultClient;
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            var secretUrl = $"{KeyVaultUrl}/secrets/{secretName}";

           var secret = await KeyVaultClient.GetSecretAsync(secretUrl).ConfigureAwait(false);

            return secret.Value;
        }

        internal static string GetKeyVaultUrlFromConfiguration(IConfiguration configuration)
        {
            //TODO: Validation etc
            return configuration["KeyVault:Url"];
        }


    }
}
