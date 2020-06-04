using System.Collections.Generic;
using System.IO;
using Grump.Abstractions;
using Grump.IO;
using File = Grump.Abstractions.File;

namespace Grump.Core
{
    public class LocalFileSystemContainer : IFileContainer
    {
        private readonly string _unvalidatedBasePath;
        private string _validatedBasePath;

        private string BasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_validatedBasePath))
                {
                    if(!Directory.Exists(_unvalidatedBasePath))
                    {
                        throw new DirectoryNotFoundException();
                    }

                    _validatedBasePath = _unvalidatedBasePath;
                }

                return _validatedBasePath;
            }
        }

        internal LocalFileSystemContainer(string basePathString)
        {
            basePathString.ShouldHaveNonEmptyValue();
            _unvalidatedBasePath = basePathString;
        }

        public string Name { get; }

        public IEnumerable<File> GetFiles()
        {
            var fileNames = Directory.EnumerateFiles(BasePath);

            foreach (var fileName in fileNames)
            {
                yield return new LocalFileSystemFile(fileName, true);
            }
        }

        public IEnumerable<IFileContainer> GetSubContainers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IFileContainer> GetFolders()
        {
            throw new System.NotImplementedException();
        }

        public File GetFile(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}