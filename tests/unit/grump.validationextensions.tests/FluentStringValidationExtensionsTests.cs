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
            string @string = null;

            Action validation = () => { @string.ShouldBe().NonEmptyOrWhitespace();  };

            validation.Should().Throw<ArgumentNullException>();
        }
    }
}
