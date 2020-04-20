using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using Grump;
using Grump.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace grump.test.unit
{
    [TestClass]
    public class CyclicEnumeratorTests
    {
        [TestMethod]
        public void CyclicEnumerator_WhenIteratedPastCount_ShouldContinueReturning()
        {
            // Arrange.
            var array = Enumerable.Range(0, 5).ToArray();
            var cycleIterator = new CyclicEnumerator<int>(array);
            var builder = new StringBuilder();

            // Act.
            for (int i = 0; i < 15; i++)
            {
                builder.Append(cycleIterator.Current);
                cycleIterator.MoveNext();
            }

            // Assert.
            var result = builder.ToString();
            result.Should().Be("012340123401234");
        }
    }
}