using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace EbillAPI.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public string eventname { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string house { get; set; }
        public string institute { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public int task_id { get; set; }

    }
}