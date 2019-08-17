using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Grump.ValidationExtensions.Tests
{
    [TestClass]
    public class FluentStringValidationExtensionsTests
    {
        [TestMethod]
        public void NonEmpty()
        {
            var fixture = new Fixture();
            string @string = null;

            Action comparison = () => { @string.ShouldNotBe().NonEmptyValue();  };

            comparison.Should().Throw<ArgumentNullException>();


        }
    }
}
