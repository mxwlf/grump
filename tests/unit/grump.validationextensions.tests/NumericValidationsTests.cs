using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Grump.ValidationExtensions.Tests
{
    [TestClass]
    public class NumericValidationsTests
    {
        [TestMethod]
        public void ShouldBeNonNegative_WhenPassingZero_ShouldNotThrow()
        {
            // Arrange.
            const int value = 0;

            // Act.
            value.ShouldBeNonNegative();

            // Assert.
            // If not thrown any exception, its a pass.
        }

        [TestMethod]
        public void ShouldBeNonNegative_WhenPassingOne_ShouldNotThrow()
        {
            // Arrange.
            const int value = 1;

            // Act.
            value.ShouldBeNonNegative();

            // Assert.
            // If not thrown any exception, its a pass.
        }

        [TestMethod]
        public void ShouldBeNonNegative_WhenPassingBiggerPositiveNumber_ShouldNotThrow()
        {
            // Arrange.
            const int value = 1000;

            // Act.
            value.ShouldBeNonNegative();

            // Assert.
            // If not thrown any exception, its a pass.
        }

        [TestMethod]
        public void ShouldBeNonNegative_WhenPassingNegativeOne_ShouldThrow()
        {
            // Arrange.
            const int value = -1;

            // Act.
            Action act = () => value.ShouldBeNonNegative();

            // Assert.
            // If not thrown any exception, its a pass.
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void ShouldBeNonNegative_WhenPassingLargerNegativeNumber_ShouldThrow()
        {
            // Arrange.
            const int value = -123;

            // Act.
            Action act = () => value.ShouldBeNonNegative();

            // Assert.
            // If not thrown any exception, its a pass.
            act.Should().Throw<ArgumentException>();
        }
    }
}