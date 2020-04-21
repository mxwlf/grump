using System;
using Microsoft.Extensions.FileProviders;

namespace Grump.Extensions.FileProviders
{
    public interface IExtendedFileProvider : IFileProvider
    {
        IFileInfo GetCurrentDirectory();

        IExtendedFileProvider MoveUp();

        IExtendedFileProvider MoveUp(string toDirectoryName);

        IExtendedFileProvider MoveUp(uint numberOfLevels);


    }
}