using System.Threading;
using System.Threading.Tasks;

namespace Grump.Abstractions
{
    public interface IWriteable : IFileCapability
    {
        Task ReplaceContent(string newContent, CancellationToken cancellationToken = default);
    }
}