using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Grump.ValidationExtensions.Tests
{
    [TestClass]
    public class ConfigurationValidationExtensionsTests
    {
        [TestMethod]
        public void ShouldBeNotNull_WhenNullObject_ShouldThrowArgumentNullException()
        {
            object @object = null;

            Action validation = () => { @object.ShouldBe().NotNull(); };

            validation.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void ShouldBeNotNull_WhenInstantiated_ShouldNotThrow()
        {
            object @object = new object();

            @object.ShouldBe().NotNull();
        }
    }
}
