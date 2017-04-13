using System;
using System.Collections.Generic;
using System.Text;

namespace RAT.ZTry
{
    public class Login
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("Username")]
        public string Username { get; set; }

        [Newtonsoft.Json.JsonProperty("Password")]
        public string Password { get; set; }

        [Newtonsoft.Json.JsonProperty("Email")]
        public string Email { get; set; }
    }
}
