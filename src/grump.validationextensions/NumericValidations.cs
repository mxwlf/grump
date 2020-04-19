using System;

namespace Grump.ValidationExtensions
{
    public static class NumericValidations
    {
        public static void ShouldBePositive(this int value, string message = null, string paramName = null)
        {
            if (value >= 1) return;

            string customMessage = null;

            if (message != null)
            {
                customMessage = message;
            }
            else
            {
                if (paramName != null)
                {
                    paramName = $"'{paramName}' ";
                }

                customMessage = $"The argument {paramName}should be a positive number, greater than zero.";
            }
            throw new ArgumentException(customMessage, paramName);
        }
        public static void ShouldBeNonNegative(this int value, string message = null, string paramName = null)
        {
            if (value >= 0) return;

            string customMessage = null;

            if (message != null)
            {
                customMessage = message;
            }
            else
            {
                if (paramName != null)
                {
                    paramName = $"'{paramName}' ";
                }

                customMessage = $"The argument {paramName}should be a non-negative number.";
            }
            throw new ArgumentException(customMessage, paramName);
        }

        public static void ShouldBeNonZero(this int value, string message = null, string paramName = null)
        {
            if (value != 0) return;

            string customMessage = null;

            if (message != null)
            {
                customMessage = message;
            }
            else
            {
                if (paramName != null)
                {
                    paramName = $"'{paramName}' ";
                }

                customMessage = $"The argument {paramName}should be other than zero.";
            }
            throw new ArgumentException(customMessage, paramName);
        }
    }
}