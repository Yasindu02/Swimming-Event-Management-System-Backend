using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbillAPI.Models
{
    public class TaskMapper
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "eventname")]
        public string EventName { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

    }
}