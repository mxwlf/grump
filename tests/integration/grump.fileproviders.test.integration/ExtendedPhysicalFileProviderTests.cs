using System.IO;
using grump.testhelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grump.FileProviders.Test.Integration
{
    [TestClass]
    public class ExtendedPhysicalFileProviderTests
    {
        private static string _testDeploymentDir;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            FileSystemSampleDataHelpers.PrepareExampleAbcDirectoryHierarchy(context.TestDeploymentDir);
        }
    }
}