using System;
using System.Collections.Generic;
using System.Text;

namespace DashboardModel
{
    public class Dashboards
    {
        public Dashboards(string id)
        {
            if (id.Length < 10)
            {
                throw new ArgumentException("Parameter");
            }
            Id = id;
        }

        public Dashboards() { }
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string DashNo { get; set; }
        public string DashString { get; set; }
        public string userId { get; set; }
    }
}
