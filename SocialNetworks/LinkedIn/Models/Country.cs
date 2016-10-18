using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class Country
    {
        public string Code { get; set; }
        public Country(JToken token)
        {
            Code = (token["code"] ?? "NA").ToString();
        }
    }
}
