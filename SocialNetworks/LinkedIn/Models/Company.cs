using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class Company
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public Company(JToken token)
        {
            ID = (token["id"] ?? "NA").ToString();
            Name = (token["name"] ?? "NA").ToString();
            Size = (token["size"] ?? "NA").ToString();
            Type = (token["type"] ?? "NA").ToString();
        }
    }
}
