using System;
using System.Collections.Generic;
using System.Text;

namespace grump.core
{
    /// <summary>
    /// Provides an abstraction for the underlying file system or other file providers.
    /// </summary>
    public interface IFileSystem
    {
        void SetDirectory(string path);

        string GetAllText(string fileName);

        void MoveUp(uint numberOfLevels = 1);

        string SearchFileExact(string fileName);



        

    }
}
