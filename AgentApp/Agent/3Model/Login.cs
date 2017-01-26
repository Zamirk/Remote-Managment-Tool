using System;
using System.Collections.Generic;
using System.Text;

namespace RAT.ZTry
{
    public class Login
    {
        //Newtonsoft.JSon used to map to a databse
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("Username")]
        public string Username { get; set; }

        [Newtonsoft.Json.JsonProperty("Password")]
        public string Password { get; set; }
    }
}
