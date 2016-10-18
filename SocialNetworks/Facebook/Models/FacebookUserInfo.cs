using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookUserInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public FacebookUserInfo(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Name = (obj["name"] ?? "NA").ToString();
        }
    }
}
