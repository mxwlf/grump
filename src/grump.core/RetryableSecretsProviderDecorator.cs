using System;
using System.Threading.Tasks;
using Grump.Abstractions;
using Polly;

namespace Grump.Core
{
    public class RetryableSecretsProviderDecorator : PollyRetryableDecoratorBase<ISecretsProvider, Task<string>>, ISecretsProvider
    {
        public string SecretName { get; set; }

        public RetryableSecretsProviderDecorator(ISecretsProvider secretsProvider) : base(secretsProvider)
        {
        }

        protected override ISyncPolicy DefaultPolicy => Polly.Policy.Handle<Exception>().WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        

        public async Task<string> GetSecretAsync(string secretName)
        {
            SecretName = secretName;

            return await RetryableAction();

        }

        protected override async Task<string> RetryableAction()
        {
            return await DecoratedInstace.GetSecretAsync(SecretName);
        }
    }
}
