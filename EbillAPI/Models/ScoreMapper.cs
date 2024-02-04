using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;

namespace EbillAPI.Models
{
    public class ScoreMapper
    {
        public int id { get; set; }

        public int user_id { get; set; }
        public string eventname { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string house { get; set; }
        public string birthday { get; set; }
        public string timing { get; set; }
        public string classes { get; set; }

      
    }
}