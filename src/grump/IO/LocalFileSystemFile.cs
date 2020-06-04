using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grump.Abstractions;

namespace Grump.IO
{
    public class LocalFileSystemFile : File, IReadableAsTextLines, IWriteable
    {
        internal LocalFileSystemFile(string filePath, bool isConfirmed) : base(filePath, isConfirmed)
        {

        }


        public IEnumerable<string> ReadAllLines()
        {
            return System.IO.File.ReadAllLines(this.FullPath);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return ReadAllLines().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ReadAllLines().GetEnumerator();
        }

        public async Task ReplaceContent(string newContent, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    // TODO: Implement backup in case of failure or cancellation.
                    System.IO.File.Delete(FullPath);

                    await System.IO.File.WriteAllTextAsync(FullPath, newContent, cancellationToken);
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}