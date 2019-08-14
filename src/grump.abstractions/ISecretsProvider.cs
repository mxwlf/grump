using System.Threading.Tasks;

namespace Grump.Abstractions
{
    /// <summary>
    /// Provides an interface to get secrets from a secure store.
    /// </summary>
    public interface ISecretsProvider
    {

        Task<string> GetSecretAsync(string secretName);

    }
}
