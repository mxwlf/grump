// using System;
// using System.IO;
// using AutoFixture;
// using FluentAssertions;
// using Grump.TestHelpers;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
//
// namespace Grump.IO.Test.Unit
// {
//     [TestClass]
//     public class PathExtensionsTests
//     {
//         private readonly char _sep;
//
//         // ReSharper disable once MemberCanBePrivate.Global
//         public TestContext TestContext { get; set; }
//
//         [ClassInitialize]
//
//         public static void TestFixtureSetup(TestContext context)
//         {
//             FileSystemSampleDataHelpers.PrepareExampleAbcDirectoryHierarchy(context.DeploymentDirectory);
//         }
//
//         public PathExtensionsTests()
//         {
//             _sep = Path.DirectorySeparatorChar;
//         }
//
//
//         [TestMethod]
//         public void FindFolderUp_WhenFolderIsFound_ShouldReturnTheFirstInstance()
//         {
//             // Arrange.
//             var currentDirectory = $"{TestContext.DeploymentDirectory}{_sep}a{_sep}bb{_sep}aaa";
//             var expectedDirectory =  $"{TestContext.DeploymentDirectory}{_sep}a";
//             // Act.
//             var foundFolder = PathExtensions.FindFolderUp(currentDirectory, "a");
//
//             // Assert.
//             expectedDirectory.Should().Be(foundFolder);
//         }
//
//         [TestMethod]
//         public void FindFolderUp_WhenFolderIsNotFound_ShouldReturnNull()
//         {
//             // Arrange.
//             var fixture = new Fixture();
//             var nonExistentFolder = fixture.Create<string>();
//             var currentDirectory = $"{TestContext.DeploymentDirectory}{_sep}a{_sep}bb{_sep}aaa";
//
//             // Act.
//             var foundFolder = PathExtensions.FindFolderUp(currentDirectory, nonExistentFolder);
//
//             // Assert.
//             foundFolder.Should().BeNull();
//         }
//
//         [TestMethod]
//         public void GetFolderUp_WhenRequest_ShouldReturnCorrectPath()
//         {
//             // Arrange.
//             var currentDirectory = $"{TestContext.DeploymentDirectory}{_sep}a{_sep}bb{_sep}aaa";
//
//             // Act.
//             var upperFolder = PathExtensions.GetFolderUp(currentDirectory);
//
//             // Assert.
//             upperFolder.Should().Be($"{TestContext.DeploymentDirectory}{_sep}a{_sep}bb");
//
//         }
//
//         [TestMethod]
//         public void GetFolderUp_WhenAtTheRoot_ShouldThrowException_WindowsVersion()
//         {
//             // Arrange.
//             var currentDirectory = $"C:{_sep}";
//
//             // Act.
//             Action action = () => PathExtensions.GetFolderUp(currentDirectory);
//
//             // Assert.
//             action.Should().Throw<InvalidOperationException>();
//         }
//
//         [TestMethod]
//         public void GetFolderUp_WhenAtTheRootWithNoSeparator_ShouldThrowException_WindowsVersion()
//         {
//             // Arrange.
//             var currentDirectory = $"C:";
//
//             // Act.
//             Action action = () => PathExtensions.GetFolderUp(currentDirectory);
//
//             // Assert.
//             action.Should().Throw<InvalidOperationException>();
//         }
//
//         [TestMethod]
//         public void GetFolderUp_WhenAtTheRoot_ShouldThrowException_LinuxVersion()
//         {
//             // Arrange.
//             var currentDirectory = $"{_sep}";
//
//             // Act.
//             Action action = () => PathExtensions.GetFolderUp(currentDirectory);
//
//             // Assert.
//             action.Should().Throw<InvalidOperationException>();
//         }
//
//         [TestMethod]
//         public void GetFolderUp_WhenRequest_ShouldReturnCorrectPath_LinuxVersion()
//         {
//             // Arrange.
//             var currentDirectory = $"{_sep}a{_sep}bb{_sep}aaa";
//
//             // Act.
//             var upperFolder = PathExtensions.GetFolderUp(currentDirectory);
//
//             // Assert.
//             upperFolder.Should().Be($"{_sep}a{_sep}bb");
//
//         }
//     }
// }