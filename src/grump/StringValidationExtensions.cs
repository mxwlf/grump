using System;

namespace Grump.Core
{
    public static class StringValidationExtensions
    {
        public static void ShouldHaveNonEmptyValue(this string value)
        {
            if (value.IsNullEmptyOrWhiteSpace())
            {
                throw new ArgumentNullException();
            }
        }
    }
}
