using Grump.Core;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace grump.testhelpers
{
    /// <summary>
    /// Secrets provider that can be used while testing in the developer's machine.
    /// </summary>
    /// <remarks>
    /// Depending on security requirements, this provider can be helpful for managing the secrets locally, in a .user file, as in typical git ignore files for VS, this file type is ignored.
    /// </remarks>
    public class UserFileTestSecretsProvider : ISecretsProvider
    {
        public string GetSecret(string secretName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecretAsync(string secretName)
        {
            throw new NotImplementedException();
        }
    }
}
