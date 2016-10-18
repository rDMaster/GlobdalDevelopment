using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class SiteStandardProfileRequestUrl
    {
        public string Url { get; set; }
        public SiteStandardProfileRequestUrl(JToken token)
        {
            Url = (token["url"] ?? "NA").ToString();
        }
    }
}
