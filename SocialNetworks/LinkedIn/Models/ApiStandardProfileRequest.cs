using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class ApiStandardProfileRequest
    {
        public Headers Header { get; set; }
        public string Url { get; set; }
        public ApiStandardProfileRequest(JToken token)
        {
            Header = new Headers(token["headers"]);
            Url = (token["url"] ?? "NA").ToString();
        }
    }
}
