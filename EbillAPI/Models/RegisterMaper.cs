using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbillAPI.Models
{
    public class RegisterMaper
    {
        [JsonProperty(PropertyName = "firstname")]
        public String Firstname { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public String Lastname { get; set; } 

        [JsonProperty(PropertyName = "password")]
        public String Password { get; set; }

    }
}