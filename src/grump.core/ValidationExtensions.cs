using System;

namespace Grump
{
    public static class ValidationExtensions
    {
        public static void MustNotBeNull(this object @object, string name = null)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}