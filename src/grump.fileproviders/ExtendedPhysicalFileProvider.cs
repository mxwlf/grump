using System;
using System.Collections.Generic;
using System.IO;
using Grump.FileProviders;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;

namespace Grump.FileProviders
{
    public class ExtendedPhysicalFileProvider : PhysicalFileProvider , IExtendedFileProvider
    {
        public ExtendedPhysicalFileProvider(string root) : base(root)
        {
        }

        public ExtendedPhysicalFileProvider(string root, ExclusionFilters filters) : base(root, filters)
        {
        }

        public IFileInfo GetCurrentDirectory()
        {
            if (base.GetFileInfo(Root).IsDirectory)
            {
                return base.GetFileInfo(Root);
            }

            return null;
        }

        public IExtendedFileProvider MoveUp()
        {
            throw new NotImplementedException();
        }

        public IExtendedFileProvider MoveUp(string toDirectoryName)
        {
            throw new NotImplementedException();
        }

        public IExtendedFileProvider MoveUp(uint numberOfLevels)
        {
            var levels = base.Root.Split(Path.DirectorySeparatorChar);

            if (numberOfLevels > levels.Length)
            {
                throw new ArgumentException("The number of levels requested exceeds the number of levels to the root.");
            }

            var newPathArray = new List<string>(levels).GetRange(0, levels.Length - (int)numberOfLevels).ToArray();

            var newRoot = string.Join(Path.DirectorySeparatorChar, newPathArray);

            return new ExtendedPhysicalFileProvider(newRoot);

        }
    }
}