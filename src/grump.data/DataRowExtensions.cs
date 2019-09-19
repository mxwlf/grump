using System;
using System.Data;

namespace Grump.Data
{
    public static class DataRowExtensions
    {

        public static T GetValueOrNull<T>(this DataRow row, string columnName) where T : class
        {
            var @value = row[columnName];

            if (@value == null)
                throw new InvalidOperationException($"Row does not contain column '{columnName}'");

            if (@value == DBNull.Value)
            {
                return null;
            }

            return (T) @value;
        }
    }
}
