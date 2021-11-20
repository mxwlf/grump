using System.Collections;
using System.Collections.Generic;
using Grump.Abstractions;

namespace Grump
{
    public abstract class TabularTextFile : IReadableAsTabularText, IReadableAsTextLines
    {

        public IEnumerator<string> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> ReadAllLines()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}