using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    [JsonObject(MemberSerialization.OptIn)]
    class TelemetryDatapoint
    {
        public TelemetryDatapoint(string device_id, int a, int b, int c)
        {
            this.device_id = device_id;
            value_1 = a;
            value_2 = b;
            value_3 = c;
        }
        [Newtonsoft.Json.JsonProperty("device_id")]
        public string device_id { get; set; }

        [Newtonsoft.Json.JsonProperty("value_1")]
        public int value_1 { get; set; }

        [Newtonsoft.Json.JsonProperty("value_2")]
        public int value_2 { get; set; }

        [Newtonsoft.Json.JsonProperty("value_3")]
        public int value_3 { get; set; }
    }
}
