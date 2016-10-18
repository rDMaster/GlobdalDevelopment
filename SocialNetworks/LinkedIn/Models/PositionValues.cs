using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.LinkedIn.Models
{
    public class PositionValues
    {
        public string ID { get; set; }
        public bool IsCurrent { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public Company Company { get; set; }
        public PositionValues(JToken token)
        {
            ID = (token["id"] ?? "NA").ToString();
            IsCurrent = bool.Parse((token["isCurrent"] ?? "false").ToString());
            Location = (token["location"] ?? "NA").ToString();
            Title = (token["title"] ?? "NA").ToString();
            Company = new Company(token["company"]);
        }
    }
}
