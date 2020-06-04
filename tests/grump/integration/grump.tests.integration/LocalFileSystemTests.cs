using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace grump.tests.integration
{
    [TestClass]
    public class LocalFileSystemTests
    {
        private static string _testDeploymentDir;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            Helpers.PrepareExampleAbcDirectoryHierarchy(context.TestDeploymentDir);
        }
    }
}