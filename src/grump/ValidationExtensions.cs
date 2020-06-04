using System;

namespace Grump
{
    public static class ValidationExtensions
    {
        public static void MustNotBeNull(this object @object, string name = null) //TODO: Move this to Simplex?
        {
            if (@object == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static T ThrowIfNull<T>(this T @object, string name = null) where T : class
        {
            @object.MustNotBeNull();

            return @object;
        }
    }
}