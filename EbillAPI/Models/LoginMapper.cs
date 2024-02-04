using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbillAPI.Models
{
    public class LoginMapper
    {
        [JsonProperty(PropertyName = "userName")]
        public String UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public String Password { get; set; }

        [JsonProperty(PropertyName = "companyBranchId")]
        public int CompanyBranchId { get; set; }

        [JsonProperty(PropertyName = "companyDepartmentId")]
        public int CompanyDepartmentId { get; set; }

        [JsonProperty(PropertyName = "userLevel")]
        public int UserLevel { get; set; }
    }
}