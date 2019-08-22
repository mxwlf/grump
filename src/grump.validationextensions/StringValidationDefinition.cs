

using Grump.Core;
using System;

namespace Grump.ValidationExtensions
{
    public class StringValidationDefinition : ValidationDefinition<string>
    {

        internal StringValidationDefinition Builder { get; private set; }

        public StringValidationDefinition(StringValidationDefinition builder):base(builder.ValidatedSpecimen)
        {
            Builder = builder;
        }

        public StringValidationDefinition(string validatedString): base(validatedString)
        {
            Builder = this;
        }

        

        public Concatenation<StringValidationDefinition> NonEmptyOrWhitespace()
        {
            if (Builder.ValidatedSpecimen.IsNullEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException();
            }
            return new Concatenation<StringValidationDefinition>(Builder);
        }
    }
}
