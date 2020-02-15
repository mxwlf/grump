using System.Collections.Generic;
using System.Globalization;

namespace Grump.Azure.Model
{
    public class To
    {
        public string email { get; set; }
    }

    public class Personalization
    {
        
        public List<To> to { get; set; }
    }

    public class From
    {
        public string email { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class EmailRequest
    {
        public List<Personalization> personalizations { get; set; }
        public From from { get; set; }
        public string subject { get; set; }
        public List<Content> content { get; set; }
    }
}