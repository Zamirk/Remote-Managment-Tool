using System;
using System.Collections.Generic;
using System.Text;

namespace RAT.ZTry
{
    public class Login
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ConnectionCode")]
        public string ConnectionCode { get; set; }

        [Newtonsoft.Json.JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }

        [Newtonsoft.Json.JsonProperty("EventHubEntity")]
        public string EventHubEntity { get; set; }

        [Newtonsoft.Json.JsonProperty("HostLink")]
        public string HostLink { get; set; }

        [Newtonsoft.Json.JsonProperty("userId")]
        public string userId { get; set; }
    }
}