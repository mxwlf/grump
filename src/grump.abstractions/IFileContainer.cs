using System.Collections.Generic;

namespace Grump.Abstractions
{
    public interface IFileContainer
    {
        string Name { get; }

        IEnumerable<File> GetFiles();

        IEnumerable<IFileContainer> GetSubContainers();

        IEnumerable<IFileContainer> GetFolders();

        File GetFile(string path);

    }
}