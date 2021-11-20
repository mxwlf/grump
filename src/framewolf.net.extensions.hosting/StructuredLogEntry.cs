using System.Collections.Generic;

namespace grump.hosting
{
    public class StructuredLogEntry
    {
        public string DateTime { get; set; }
        public string LogLevel { get; set; }

        public string OperationName { get; set; }

        public long ElapsedTimeInMilliseconds  { get; set; }
        
        public IDictionary<string, object> Data { get; set; }

        public static StructuredLogEntry Build()
        {
            return new StructuredLogEntry();
        }
        
    }
}