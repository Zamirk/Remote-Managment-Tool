using System;
using System.Collections.Generic;
using System.Text;

namespace DashboardModel
{
    public class Dashboards
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }
        public string DashNo { get; set; }
        public string DashString { get; set; }
        public string Username { get; set; }
    }
}
