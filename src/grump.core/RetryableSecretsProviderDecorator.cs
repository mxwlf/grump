using System;
using System.Threading.Tasks;
using Grump.Abstractions;
using Polly;

namespace Grump.Core
{
    public class RetryableSecretsProviderDecorator : ISecretsProvider
    {
        private readonly ISecretsProvider _secretsProvider;

        public RetryableSecretsProviderDecorator(ISecretsProvider secretsProvider)
        {
            _secretsProvider = secretsProvider ?? throw new ArgumentNullException();
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            //TODO: Need to implement policies from the caller so we do more targetted exception handling for transient exceptions.
            Policy
                .Handle<Exception>()
                 .WaitAndRetry(5, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));


            var policyResult = await Policy
              .Handle<Exception>()
              .RetryAsync()
              .ExecuteAndCaptureAsync(() => GetSecretAsyncCoreCall(secretName));

            if (policyResult.Outcome == OutcomeType.Failure)
            {
                throw new Exception("An exception occured after trying multiple times to acess the secrets provider.", policyResult.FinalException);
            }

            return policyResult.Result;
        }

        private async Task<string> GetSecretAsyncCoreCall(string secretName)
        {
            return await _secretsProvider.GetSecretAsync(secretName);
        }
    }
}
