using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class Values
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Values(JToken token)
        {
            Name = (token["name"] ?? "NA").ToString();
            Value = (token["value"] ?? "NA").ToString();
        }
    }
}
