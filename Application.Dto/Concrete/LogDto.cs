using Newtonsoft.Json;
using System;

namespace Application.Dto.Concrete
{
    public class LogDto
    {
        [JsonProperty("@t")]
        public DateTime? t { get; set; }

        [JsonProperty("@mt")]
        public string mt { get; set; }

        [JsonProperty("@l")]
        public string l { get; set; }

        [JsonProperty("@x")]
        public string x { get; set; }


        public string LocalIdentifier { get; set; }
        public string TraceIdentifier { get; set; }
        public string RemoteIpAddress { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string MachineName { get; set; }
        public int? FileLineNumber { get; set; }
        public int? FileColumnNumber { get; set; }
        public string FileName { get; set; }

        public string Timestamp
        {
            get
            {
                if (this.t.HasValue)
                    return this.t.Value.ToString("yyyy-MM-dd hh:MM:ss.zzz");

                return null; ;
            }
        }
        public string MessageTemplate
        {
            get
            {
                return this.mt;
            }
        }
        public string Level
        {
            get
            {
                return this.l;
            }
        }
        public string Message
        {
            get
            {
                return this.x;
            }
        }
    }
}
