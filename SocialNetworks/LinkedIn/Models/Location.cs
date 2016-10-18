using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class Location
    {
        public Country Country { get; set; }
        public string Name { get; set; }
        public Location(JToken token)
        {
            Country = new Country(token["country"]);
            Name = (token["name"] ?? "NA").ToString();
        }
    }
}
