
using Grump.Semantics;

namespace Grump.ValidationExtensions
{
    public static class FluentStringValidationExtensions
    {
        public static StringCharacteristics ShouldNotBe(this string @string)
        {
            var builder = new StringValidationsBuilder(@string);
            
            return new StringCharacteristics(builder);

        }
    }
}
