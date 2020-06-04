
using System.Collections.Generic;

namespace Grump.Abstractions
{
    public interface IReadableAsTextLines : IFileCapability, IEnumerable<string>
    {
        IEnumerable<string> ReadAllLines();
    }
}