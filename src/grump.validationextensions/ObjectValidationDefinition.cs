
using System;

namespace Grump.ValidationExtensions
{
    public class ObjectValidationDefinition : ValidationDefinition<object>
    {
        internal ObjectValidationDefinition Builder { get; private set; }

        public ObjectValidationDefinition(object validatedObject) : base(validatedObject)
        {
            Builder = this;
        }

        public ObjectValidationDefinition(ObjectValidationDefinition builder):base(builder.ValidatedSpecimen)
        {
            Builder = builder;
        }



        public Concatenation<ObjectValidationDefinition> NotNull()
        {
            if (Builder.ValidatedSpecimen == null)
            {
                throw new ArgumentNullException();
            }
            return new Concatenation<ObjectValidationDefinition>(Builder);
        }
    }
}
