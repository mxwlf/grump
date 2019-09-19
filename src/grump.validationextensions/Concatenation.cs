using System;
using System.Collections.Generic;
using System.Text;

namespace Grump.ValidationExtensions
{
    public class Concatenation<T>
    {
        public T Builder { get; set; }

        public T And { get; set; }

        public T Or { get; set; }

        public Concatenation(T builder)
        {
            Builder = builder;
        }
    }
}
