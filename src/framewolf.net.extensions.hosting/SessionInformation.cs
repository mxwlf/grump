using System;

namespace framewolf.net.Extensions.Hosting
{
    public class SessionInformation
    {
        public StructuredLogEntry[] Entries { get; set; }

        public string SessionId { get; set; }

        public DateTime DateTime { get; set; }

        // public OperationAverage[] Averages { get; set; }
        
    }
}