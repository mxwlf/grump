

using Grump.Core;
using Grump.ValidationExtensions;
using System;

namespace Grump.Semantics
{
    public class StringCharacteristics
    {
        internal bool NonEmptyValueFlag { get; set; }

        internal StringValidationsBuilder Builder { get; private set; }

        internal StringCharacteristics(StringValidationsBuilder builder)
        {
            Builder = builder;
        }
        

        public void NonEmptyValue()
        {
            if (Builder.StringUnderValidation.IsNullEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException();
            }
        }
    }
}
