using System.IO;

namespace grump.tests.integration
{
    public class Helpers
    {
        public static void PrepareExampleAbcDirectoryHierarchy(string rootFolder)
        {
            var directory = new DirectoryInfo(rootFolder);
            directory.CreateSubdirectory("a/aa/aaa");
            directory.CreateSubdirectory("a/aa/bbb");
            directory.CreateSubdirectory("a/aa/ccc");
            directory.CreateSubdirectory("a/bb/aaa");
            directory.CreateSubdirectory("a/bb/bbb");
            directory.CreateSubdirectory("a/bb/cccc");
            directory.CreateSubdirectory("a/cc/aaa");
            directory.CreateSubdirectory("a/cc/bbb");
            directory.CreateSubdirectory("a/cc/ccc");

            directory.CreateSubdirectory("b/aa/aaa");
            directory.CreateSubdirectory("b/aa/bbb");
            directory.CreateSubdirectory("b/aa/ccc");
            directory.CreateSubdirectory("b/bb/aaa");
            directory.CreateSubdirectory("b/bb/bbb");
            directory.CreateSubdirectory("b/bb/ccc");
            directory.CreateSubdirectory("b/cc/aaa");
            directory.CreateSubdirectory("b/cc/bbb");
            directory.CreateSubdirectory("b/cc/ccc");

            directory.CreateSubdirectory("c/aa/aaa");
            directory.CreateSubdirectory("c/aa/bbb");
            directory.CreateSubdirectory("c/aa/ccc");
            directory.CreateSubdirectory("c/bb/aaa");
            directory.CreateSubdirectory("c/bb/bbb");
            directory.CreateSubdirectory("c/bb/ccc");
            directory.CreateSubdirectory("c/cc/aaa");
            directory.CreateSubdirectory("c/cc/bbb");
            directory.CreateSubdirectory("c/cc/ccc");

        }
    }
}