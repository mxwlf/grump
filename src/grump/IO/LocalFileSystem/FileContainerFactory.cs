using Grump.Abstractions;
using Grump.Core;

namespace Grump.IO.LocalFileSystem
{
    public class FileContainerFactory : IFileContainerFactory
    {
        public IFileContainer GetFileContainer(string containerUri)
        {
            return new LocalFileSystemContainer(containerUri);
        }
    }
}