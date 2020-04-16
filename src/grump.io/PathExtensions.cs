using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Grump.Core;

namespace Grump.IO
{
    public static class PathExtensions
    {
        public static string FindFolderUp(string originalPath, string searchedFolderName)
        {
            // For the time being we will consider case-insensitive. This either has to respect the OS case sensitivity or being flexible.
            var comparisonType = StringComparison.InvariantCultureIgnoreCase;

            originalPath.ShouldHaveNonEmptyValue();
            searchedFolderName.ShouldHaveNonEmptyValue();

            //Quick exit
            if (!originalPath.Contains(originalPath, comparisonType))
            {
                return null;
            }

            // TODO: Validate path

            var pathSegments = originalPath.Split(Path.DirectorySeparatorChar);
            
            var found = false;
            var reverseFoundPath = new List<string>();

            for (int i = pathSegments.Length-1 ; i >= 0; i--)
            {
                if (found || pathSegments[i].Equals(searchedFolderName, comparisonType))
                {
                    found = true;
                    reverseFoundPath.Add(pathSegments[i]);
                }
            }

            if (!found)
            {
                return null;
            }

            var foundPath = String.Join(Path.DirectorySeparatorChar, reverseFoundPath.ToArray().Reverse().ToArray());


            string exactFoundPath;

            if (!TryGetExactPath(foundPath, out exactFoundPath))
            {
                throw new ArgumentException("The resulting path is not valid.");
            }

            return exactFoundPath;
        }

        /// Gets the exact case used on the file system for an existing file or directory.
        /// </summary>
        /// <param name="path">A relative or absolute path.</param>
        /// <param name="exactPath">The full path using the correct case if the path exists.  Otherwise, null.</param>
        /// <returns>True if the exact path was found.  False otherwise.</returns>
        /// <remarks>
        /// This supports drive-lettered paths and UNC paths, but a UNC root
        /// will be returned in title case (e.g., \\Server\Share).
        /// Thanks to Bill Menees (https://github.com/menees)
        /// </remarks>
        public static bool TryGetExactPath(string path, out string exactPath)
        {
            bool result = false;
            exactPath = null;

            // DirectoryInfo accepts either a file path or a directory path, and most of its properties work for either.
            // However, its Exists property only works for a directory path.
            DirectoryInfo directory = new DirectoryInfo(path);
            if (File.Exists(path) || directory.Exists)
            {
                List<string> parts = new List<string>();

                DirectoryInfo parentDirectory = directory.Parent;
                while (parentDirectory != null)
                {
                    FileSystemInfo entry = parentDirectory.EnumerateFileSystemInfos(directory.Name).First();
                    parts.Add(entry.Name);

                    directory = parentDirectory;
                    parentDirectory = directory.Parent;
                }

                // Handle the root part (i.e., drive letter or UNC \\server\share).
                string root = directory.FullName;
                if (root.Contains(':'))
                {
                    root = root.ToUpper();
                }
                else
                {
                    string[] rootParts = root.Split(Path.DirectorySeparatorChar);
                    root = string.Join(Path.DirectorySeparatorChar, rootParts.Select(part => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(part)));
                }

                parts.Add(root);
                parts.Reverse();
                exactPath = Path.Combine(parts.ToArray());
                result = true;
            }

            return result;
        }

        public static string GetFolderUp(string originalPath)
        {
            originalPath.ShouldHaveNonEmptyValue();

            var pathSegments = originalPath.Split(Path.DirectorySeparatorChar);

            // If the path has a directory separator at the end, it produces an empty segment at the end.
            if (pathSegments[pathSegments.Length-1] == string.Empty)
            {
                pathSegments = pathSegments.SkipLast(1).ToArray();
            }

            if (pathSegments.Length < 2)
            {
                throw new InvalidOperationException("There is no folder up the hierarchy");
            }

            var newPathSegments = pathSegments.SkipLast(1);

            return string.Join(Path.DirectorySeparatorChar, newPathSegments);
        }
    }
}